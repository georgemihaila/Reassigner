using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.FileHandling.Abstractions
{
    /// <summary>
    /// Represents an object based on a <see cref="DataTable"/> with specific operations.
    /// </summary>
    public abstract class DataTableBase
    {
        protected DataTable _dataTable;

        /// <summary>
        /// Gets the row at the specified index as a list of objects.
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="index">The row index.</param>
        public IEnumerable<T> GetRow<T>(int index) => _dataTable.Rows[index].ItemArray.ToList().Select(x => (T)x);

        /// <summary>
        /// Gets the column at the specified index as a list of objects.
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="index">The row index.</param>
        public IEnumerable<T> GetColumn<T>(int index) => Enumerable.Range(0, _dataTable.Rows.Count - 1).Select(i => (T)_dataTable.Rows[i].ItemArray[index]);
    }
}
