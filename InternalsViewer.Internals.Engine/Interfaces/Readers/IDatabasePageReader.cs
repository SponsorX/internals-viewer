using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Interfaces.Readers
{
    public interface IDatabasePageReader
    {
        IDbConnection Connection { get; set; }

        Task<RawPage> Read(int databaseId, PageAddress pageAddress);
    }
}