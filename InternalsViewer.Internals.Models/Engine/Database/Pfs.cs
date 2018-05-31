using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class Pfs
    {
        public List<PfsPage> Pages;

        public Pfs()
        {
            Pages = new List<PfsPage> {  };
        }

        public PfsByte PagePfsByte(int page)
        {
            return Pages[page / DatabaseContainer.PfsInterval].PfsBytes[page % DatabaseContainer.PfsInterval];
        }
    }
}
