﻿using System;
using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Structures;
using InternalsViewer.Internals.RecordLoaders;
using InternalsViewer.Internals.Compression;
using InternalsViewer.Internals.Pages;

namespace InternalsViewer.Internals.Records
{
    public class CompressedDataRecord : Record<CompressedDataRecord>
    {
        public CompressedDataRecord(Page page, ushort slotOffset, Structure structure)
            : base(page, slotOffset, structure)
        {
            CdItems = new List<CdArrayItem>();

            CompressedDataRecordLoader.Load(this);
        }

        //public byte[] CdArray
        //{
        //    get { return cdArray; }
        //    set { cdArray = value; }
        //}

        public List<CdArrayItem> CdItems { get; }

        public CdArrayItem[] CdItemsArray => CdItems.ToArray();

        public byte GetCdByte(int columnId)
        {
            return CdItems[columnId / 2].Values[columnId % 2];
        }

        public short CompressedSize { get; set; }
    }
}
