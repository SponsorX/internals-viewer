﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InternalsViewer.Internals.Engine.Address;

namespace InternalsViewer.Internals.Engine.Database
{
    public class Database
    {
        public const int AllocationInterval = 511232;
        public const int PfsInterval = 8088;
        private readonly Dictionary<int, Allocation> bcm = new Dictionary<int, Allocation>();
        private readonly Dictionary<int, Allocation> dcm = new Dictionary<int, Allocation>();
        private readonly Dictionary<int, Allocation> gam = new Dictionary<int, Allocation>();
        private readonly Dictionary<int, Pfs> pfs = new Dictionary<int, Pfs>();
        private readonly Dictionary<int, Allocation> sGam = new Dictionary<int, Allocation>();

        public int DatabaseId { get; }

        public string Name { get; }

        public Dictionary<int, Allocation> Gam
        {
            get
            {
                if (gam.Count == 0)
                {
                    LoadAllocations();
                }
                return gam;
            }
        }

        public Dictionary<int, Allocation> SGam
        {
            get
            {
                if (sGam.Count == 0)
                {
                    LoadAllocations();
                }
                return sGam;
            }
        }

        public Dictionary<int, Allocation> Dcm
        {
            get
            {
                if (dcm.Count == 0)
                {
                    LoadAllocations();
                }
                return dcm;
            }
        }

        public Dictionary<int, Allocation> Bcm
        {
            get
            {
                if (bcm.Count == 0)
                {
                    LoadAllocations();
                }
                return bcm;
            }
        }

        public Dictionary<int, Pfs> Pfs
        {
            get
            {
                if (pfs.Count == 0)
                {
                    LoadPfs();
                }
                return pfs;
            }
        }

        public List<DatabaseFile> Files { get; set; } = new List<DatabaseFile>();

        public bool Compatible { get; }

        public byte CompatibilityLevel { get; set; }

        public string ConnectionString { get; set; }

        public Database(string connectionString, int databaseId, string name, int state, byte compatibilityLevel)
        {
            ConnectionString = connectionString;
            DatabaseId = databaseId;
            Name = name;
            CompatibilityLevel = compatibilityLevel;

            Compatible = (compatibilityLevel >= 90 && state == 0);

            LoadFiles();
        }

        public void Refresh()
        {
            LoadAllocations();
        }

        public int FileSize(int fileId)
        {
            return Files.Find(file => file.FileId == fileId).Size;
        }

        private void LoadAllocations()
        {
            foreach (var file in Files)
            {
                gam.Add(file.FileId, new Allocation(this, new PageAddress(file.FileId, 2)));
                sGam.Add(file.FileId, new Allocation(this, new PageAddress(file.FileId, 3)));
                dcm.Add(file.FileId, new Allocation(this, new PageAddress(file.FileId, 6)));
                bcm.Add(file.FileId, new Allocation(this, new PageAddress(file.FileId, 7)));
            }
        }

        private void LoadPfs()
        {
            foreach (var file in Files)
            {
                pfs.Add(file.FileId, new Pfs(this, file.FileId));
            }
        }

        public void RefreshPfs(int fileId)
        {
            pfs[fileId] = new Pfs(this, fileId);
        }

        private void LoadFiles()
        {
            var sqlCommand = Properties.Resources.SQL_Files;

            var filesDataTable = DataAccess.GetDataTable(ConnectionString, sqlCommand, Name, "Files", CommandType.Text);

            foreach (DataRow r in filesDataTable.Rows)
            {
                var file = new DatabaseFile((int)r["file_id"], this);

                file.FileGroup = r["filegroup_name"].ToString();
                file.Name = r["name"].ToString();
                file.PhysicalName = r["physical_name"].ToString();
                file.Size = (int)r["size"];
                file.TotalExtents = (int)r["total_extents"];
                file.UsedExtents = (int)r["used_extents"];

                Files.Add(file);
            }
        }

        public DataTable Tables()
        {
            var sqlCommand = Properties.Resources.SQL_Database_Tables;

            return DataAccess.GetDataTable(ConnectionString, sqlCommand, Name, "Tables", CommandType.Text);
        }

        public DataTable AllocationUnits()
        {
            var sqlCommand = Properties.Resources.SQL_Allocation_Units;

            return DataAccess.GetDataTable(ConnectionString, sqlCommand, Name, "Tables", CommandType.Text);
        }

        public DataTable TableInfo(int objectId)
        {
            return DataAccess.GetDataTable(ConnectionString,
                                           Properties.Resources.SQL_Table_Info,
                                           Name,
                                           "Tables",
                                           CommandType.Text,
                                           new SqlParameter[1] { new SqlParameter("object_id", objectId) });
        }

        public DataTable TableColumns(int objectId)
        {
            return null;
        }

        internal int GetSize(DatabaseFile databaseFile)
        {
            return (int)DataAccess.GetScalar(ConnectionString,
                                             Name,
                                             Properties.Resources.SQL_File_Size,
                                             CommandType.Text,
                                             new SqlParameter[1] { new SqlParameter("file_id", databaseFile.FileId) });
        }

        internal static byte GetCompatabilityLevel(string connectionString, string database)
        {
            byte compatabilityLevel;

            compatabilityLevel = (byte)DataAccess.GetScalar(connectionString,
                                                           "master",
                                                           Properties.Resources.SQL_CompatabilityLevel,
                                                           CommandType.Text,
                                                           new SqlParameter[1]
                                                                         {
                                                                             new SqlParameter("name", database)
                                                                         });
            return compatabilityLevel;
        }
    }
}