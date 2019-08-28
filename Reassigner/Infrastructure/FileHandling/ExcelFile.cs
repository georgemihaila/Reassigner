using Reassigner.Infrastructure.FileHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.FileHandlers
{
    /// <summary>
    /// Represents an Excel file.
    /// </summary>
    public class ExcelFile : DataTableBase, IDisposable
    {
        private readonly string _path;
        private readonly List<string> _columnNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelFile" /> class.
        /// </summary>
        /// <param name="path">The Excel file path.</param>
        /// <param name="hasHeader">Whether the table has a header.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public ExcelFile(string path, bool hasHeader = true)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(string.Format("File \"{0}\" was not found.", path));
            _path = path;
            if (hasHeader) _columnNames = new List<string>();
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(_path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    if (hasHeader)
                        _columnNames.Add(firstRowCell.Text);
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                _dataTable = tbl;
            }
        }

        /// <summary>
        /// Automatically matches Excel columns to the properties of type <typeparamref name="T" /> and returns a populated list of objects.
        /// </summary>
        /// <param name="stringTransformOperation">The operation that will be applied to each column and each property name in order to determine equality.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public IEnumerable<T> AsEntityList<T>(Func<string, string> stringTransformOperation) where T: class, new()
        {
            if (_columnNames == null || _columnNames.Count == 0)
                throw new InvalidOperationException(string.Format("Could not match Excel columns to the type {0} because the file does not have a header.", typeof(T)));

            var props = typeof(T).GetProperties();
            var matching = props.Where(x => _columnNames.Select(col => stringTransformOperation(col)).ToList().Contains(stringTransformOperation(x.Name)));
            for (int row = 0; row < _dataTable.Rows.Count; row++)
            {
                T instance = new T();
                foreach (var prop in matching)
                {
                    prop.SetValue(instance, _dataTable.Rows[row].ItemArray[_columnNames.Select(x => stringTransformOperation(x)).ToList().IndexOf(stringTransformOperation(prop.Name))]);
                }
                yield return instance;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _dataTable.Dispose();
        }
    }
}
