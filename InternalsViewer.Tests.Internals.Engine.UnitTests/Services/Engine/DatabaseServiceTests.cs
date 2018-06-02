using System.Data.SqlClient;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Readers.Pages;
using InternalsViewer.Internals.Engine.Services.Engine;
using InternalsViewer.Internals.Engine.Services.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Services.Engine
{
    [TestClass]
    public class DatabaseServiceTests
    {
        [TestMethod]
        public async Task Can_Load_Test_Database()
        {
            var connection = new SqlConnection(Properties.Settings.Default.TestDatabaseConnectionString);

            var metadataService = new MetadataService();
            var pageReader = new DatabasePageReader();
            var pageFreeSpaceService = new PageFreeSpaceService(pageReader);
            var allocationService = new AllocationService(pageReader);

            metadataService.Connection = connection;
            pageReader.Connection = connection;
            pageFreeSpaceService.Connection = connection;

            var service = new DatabaseService(metadataService, allocationService, pageFreeSpaceService);

            var result = await service.GetDatabase(7);
        }
    }
}