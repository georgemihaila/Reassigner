using NUnit.Framework;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using System.Reflection;

namespace Tests
{
    public class TypeUnitTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var props = typeof(Ticket).GetProperties();
            System.Console.WriteLine(props);
        }
    }
}