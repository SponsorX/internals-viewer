using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Engine.Interfaces.Services.Metadata;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class DatabaseService
    {
        public DatabaseService(IMetadataService metadataService,
                               IAllocationService allocationService,
                               IPageFreeSpaceService pageFreeSpaceService)
        {
            MetadataService = metadataService;
            AllocationService = allocationService;
            PageFreeSpaceService = pageFreeSpaceService;
        }

        public IMetadataService MetadataService { get; set; }

        public IAllocationService AllocationService { get; set; }

        public IPageFreeSpaceService PageFreeSpaceService { get; set; }

        public async Task<DatabaseContainer> GetDatabase(int databaseId)
        {
            var databaseInfo = await MetadataService.GetDatabase();

            var database = new DatabaseContainer
            {
                DatabaseId = databaseId,
                Files = databaseInfo.Files,
                CompatibilityLevel = databaseInfo.CompatabilityLevel,
                AllocationUnits =  await MetadataService.GetAllocationUnits()
            };

            await LoadAllocations(database);

            await LoadPfs(database);

            return database;
        }

        private async Task LoadAllocations(DatabaseContainer database)
        {
            foreach (var file in database.Files)
            {
                var fileSize = file.Size;

                var gam = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 2), fileSize);
                database.Gam.Add(file.FileId, gam);

                var sGam = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 3), fileSize);
                database.SGam.Add(file.FileId, sGam);

                var dcm = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 6), fileSize);
                database.Dcm.Add(file.FileId, dcm);

                var bcm = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 7), fileSize);
                database.Bcm.Add(file.FileId, bcm);
            }
        }

        private async Task LoadPfs(DatabaseContainer database)
        {
            foreach (var file in database.Files)
            {
                var pfs = await PageFreeSpaceService.GetPfs(database.DatabaseId, file.Size, file.FileId);

                database.Pfs.Add(file.FileId, pfs);
            }
        }
    }
}