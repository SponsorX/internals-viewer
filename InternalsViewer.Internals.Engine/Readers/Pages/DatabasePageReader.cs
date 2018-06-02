using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Readers.Headers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Readers.Pages
{
    /// <summary>
    /// Reads a page using a database connection with DBCC PAGE
    /// </summary>
    public class DatabasePageReader : PageReader, IDatabasePageReader
    {
        public IDbConnection Connection { get; set; }

        public async Task<RawPage> Read(int databaseId, PageAddress pageAddress)
        {
            var pageCommand = string.Format(Properties.Resources.Sql_DatabasePageReader_Page,
                                            databaseId,
                                            pageAddress.FileId,
                                            pageAddress.PageId,
                                            2);
            var offset = 0;
            var data = new byte[Page.Size];

            var headerData = new Dictionary<string, string>();

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            var command = new SqlCommand(pageCommand, (SqlConnection)Connection)
            {
                CommandType = CommandType.Text
            };

            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    if (reader[0].ToString() == "DATA:" && reader[1].ToString().StartsWith("Memory Dump"))
                    {
                        var currentRow = reader[3].ToString();

                        offset = ReadData(currentRow, offset, data);
                    }
                    else if (reader[0].ToString() == "PAGE HEADER:")
                    {
                        headerData.Add(reader[2].ToString(), reader[3].ToString());
                    }
                }

                reader.Close();
            }

            command.Dispose();
            Connection.Close();

            return GetRawPage(data, headerData);
        }

        private static RawPage GetRawPage(byte[] data, IDictionary<string, string> headerData)
        {
            var header = new Header();

            new DictionaryHeaderReader(headerData).LoadHeader(header);

            return new RawPage
            {
                Data = data,
                Header = header
            };
        }
    }
}
