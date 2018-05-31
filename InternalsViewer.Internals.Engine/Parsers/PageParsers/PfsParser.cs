using System;
using InternalsViewer.Internals.Engine.Interfaces.Parsers;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Parsers.PageParsers
{
    public class PfsParser : IPageParser<PfsPage>
    {
        public PfsPage Parse(RawPage page)
        {
            if (page.Header.PageType != PageType.Pfs)
            {
                throw new InvalidOperationException($"Page is not a PFS page - {page.Header.PageType}");
            }

            var pfsPage = new PfsPage
            {
                Header = page.Header,
                Data = page.Data
            };

            LoadPfsBytes(pfsPage);

            return pfsPage;
        }

        /// <summary>
        /// Loads the PFS bytes collection
        /// </summary>
        private static void LoadPfsBytes(PfsPage page)
        {
            var pfsData = new byte[PfsPage.PfsSize];

            Array.Copy(page.Data, PfsPage.PfsOffset, pfsData, 0, PfsPage.PfsSize);

            foreach (var pfsByte in pfsData)
            {
                page.PfsBytes.Add(PfsByteParser.Parse(pfsByte));
            }
        }
    }
}