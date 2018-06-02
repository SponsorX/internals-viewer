﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using InternalsViewer.Internals.Engine.Data.TypeMappers;
using InternalsViewer.Internals.Engine.Interfaces.Services.Metadata;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Engine.Services.Metadata
{
    public class MetadataService : IMetadataService
    {
        public IDbConnection Connection { get; set; }

        public MetadataService()
        {
            SqlMapper.ResetTypeHandlers();
            SqlMapper.AddTypeHandler(PageAddressTypeMapper.Default);
        }

        public  async Task<Database> GetDatabase()
        {
            var result = await Connection.QueryAsync<Database, File[], Database>(Properties.Resources.Sql_Metadata_Database,
                (database, file) =>
                {
                    database.Files = file;

                    return database;
                }, splitOn: "FileId");

            return result.FirstOrDefault();
        }

        public Task<IEnumerable<AllocationUnit>> GetAllocationUnits()
        {
            return Connection.QueryAsync<AllocationUnit>(Properties.Resources.Sql_Metadata_AllocationUnits);
        }

        public Task<int> GetFileSize(int fileId)
        {
            return Connection.ExecuteScalarAsync<int>(Properties.Resources.Sql_Metadata_FileSize,
                                                      new { FileId = fileId });
        }

        public Task<byte> GetCompatabilityLevel()
        {
            return Connection.ExecuteScalarAsync<byte>(Properties.Resources.Sql_Metadata_CompatabilityLevel);
        }
    }
}
