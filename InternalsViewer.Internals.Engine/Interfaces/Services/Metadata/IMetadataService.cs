using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Engine.Interfaces.Services.Metadata
{
    public interface IMetadataService
    {
        IDbConnection Connection { get; set; }

        Task<IEnumerable<AllocationUnit>> GetAllocationUnits();

        Task<Database> GetDatabase(string name);
    }
}