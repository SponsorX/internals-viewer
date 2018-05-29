﻿using System;
using System.Collections.ObjectModel;
using InternalsViewer.Internals.Pages;
using System.Collections.Generic;
using InternalsViewer.Internals.Records;

namespace InternalsViewer.Internals.BlobPointers
{
    public class RootField : BlobField<RootField>
    {
        public const int ChildOffset = 12;
        public const short LevelOffset = 2;
        public const int TimestampOffset = 6;
        public const int UnusedOffset = 3;
        public const int UpdateSeqOffset = 4;

        public RootField(byte[] data, int offset)
            : base(data, offset)
        {
            Unused = data[UnusedOffset];

            Mark(p=>p.Unused, offset + UnusedOffset, sizeof(byte));

            Level = data[LevelOffset];

            Mark(p => p.Level, offset + RootField.LevelOffset, sizeof(byte));

            Timestamp = BitConverter.ToInt32(data, TimestampOffset);

            Mark(p => p.Timestamp, offset + RootField.TimestampOffset, sizeof(int));

            UpdateSeq = BitConverter.ToInt16(data, UpdateSeqOffset);

            Mark(p => p.UpdateSeq, offset + RootField.UpdateSeqOffset, sizeof(short));
        }

        protected override void LoadLinks()
        {
            Links = new List<BlobChildLink>();

            SlotCount = (Data.Length - 12) / 12;

            for (var i = 0; i < SlotCount; i++)
            {
                Mark(p => p.LinksArray, "Child " + i + " - ", i);

                var length = BitConverter.ToInt32(Data, ChildOffset + (i * 12));

                var rowIdData = new byte[8];
                Array.Copy(Data, ChildOffset + (i * 12) + 4, rowIdData, 0, 8);

                var rowId = new RowIdentifier(rowIdData);

                var link = new BlobChildLink(rowId, 0, length);

                link.Mark(p => p.Length, Offset + RootField.ChildOffset + (i * 12), sizeof(int));

                link.Mark(p => p.RowIdentifier, Offset + RootField.ChildOffset + (i * 12) + sizeof(int), 8);

                Links.Add(link);
            }
        }

        [Mark(MarkType.SlotCount)]
        public int SlotCount { get; set; }

        [Mark(MarkType.Level)]
        public byte Level { get; set; }

        [Mark(MarkType.Unused)]
        public byte Unused { get; set; }

        [Mark(MarkType.UpdateSeq)]
        public short UpdateSeq { get; set; }
    }
}
