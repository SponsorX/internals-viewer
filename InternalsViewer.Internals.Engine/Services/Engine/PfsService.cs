using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Parsers;
using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class PfsService
    {
        public PfsService(IDatabasePageReader pageReader)
        {
            PageReader = pageReader;
        }

        protected IDatabasePageReader PageReader { get; set; }

        public IDbConnection Connection { get; set; }

        public async Task<Pfs> GetPfs(int databaseId, int fileSize, int fileId)
        {
            var pfs = new Pfs();

            var pfsCount = (int)Math.Ceiling(fileSize / (decimal)DatabaseContainer.PfsInterval);

            var page = await GetPfsPage(databaseId, new PageAddress(fileId, 1));
            pfs.Pages.Add(page);

            if (pfsCount > 1)
            {
                for (var i = 1; i < pfsCount; i++)
                {
                    page = await GetPfsPage(databaseId, new PageAddress(fileId, i * DatabaseContainer.PfsInterval));
                    pfs.Pages.Add(page);
                }
            }

            return pfs;
        }

        private async Task<PfsPage> GetPfsPage(int databaseId, PageAddress addresss)
        {
            var page = await PageReader.Read(databaseId, addresss);

            var result = new PfsParser().Parse(page);

            return result;
        }
    }
}
