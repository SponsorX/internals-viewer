﻿using System;
using System.Collections.ObjectModel;
using InternalsViewer.Internals.Pages;
using System.Collections.Generic;
using InternalsViewer.Internals.Engine.Address;

namespace InternalsViewer.Internals.BlobPointers
{
    public class PointerField : BlobField
    {
        public const int RowIdOffset = 8;

        public PointerField(byte[] data, int offset)
            : base(data, offset)
        {
            Mark("Timestamp", Offset + sizeof(byte), sizeof(int));

            Timestamp = BitConverter.ToInt32(data, 0);
        }

        protected override void LoadLinks()
        {
            Links = new List<BlobChildLink>();

            var rowIdData = new byte[8];
            Array.Copy(Data, RowIdOffset, rowIdData, 0, 8);

            Mark("LinksArray", string.Empty, 0);

            var rowId = new RowIdentifier(rowIdData);

            var link = new BlobChildLink(rowId, 0, 0);

            link.Mark("RowIdentifier", Offset + RowIdOffset, 8);

            Links.Add(link);
        }
    }
}
