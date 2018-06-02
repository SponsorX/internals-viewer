using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Allocations;

namespace InternalsViewer.Internals.Engine.Interfaces.Services.Engine
{
    public interface IPageFreeSpaceService
    {
        IDbConnection Connection { get; set; }

        Task<PageFreeSpace> GetPfs(int databaseId, int fileSize, int fileId);
    }
}