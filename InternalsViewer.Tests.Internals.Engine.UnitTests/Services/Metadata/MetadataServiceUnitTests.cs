using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Services.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Services.Metadata
{
    [TestClass]
    public class MetadataServiceUnitTests
    {
        [TestMethod]
        public async Task Can_Get_Database()
        {
            var service = CreateService();

            var result = await service.GetDatabase();

            Assert.AreEqual(result.Name, "aaa");
        }

        public static MetadataService CreateService()
        {
            var connection = new SqlConnection(Properties.Settings.Default.TestDatabaseConnectionString);

            var service = new MetadataService();

            service.Connection = connection;

            return service;
        }

        [TestMethod]
        public async Task Can_Get_AllocationUnits()
        {
            var service = CreateService();

            var result = await service.GetAllocationUnits();

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task Can_Get_CompatabilityVersion()
        {
            var service = CreateService();

            var result = await service.GetCompatabilityLevel();

            Assert.IsTrue(result > 90);
        }

        [TestMethod]
        public async Task Can_Get_FileSize()
        {
            var service = CreateService();

            var result = await service.GetFileSize(1);

            Assert.IsTrue(result > 1);
        }
    }
}
