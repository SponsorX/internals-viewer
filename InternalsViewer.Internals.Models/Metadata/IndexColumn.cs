﻿namespace InternalsViewer.Internals.Models.Metadata
{
    public class IndexColumn : Column
    {
        public bool Key { get; set; }

        public bool IncludedColumn { get; set; }

        public int IndexColumnId { get; set; }
    }
}
