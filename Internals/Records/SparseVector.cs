﻿using System;
using InternalsViewer.Internals.RecordLoaders;
using InternalsViewer.Internals.Structures;

namespace InternalsViewer.Internals.Records
{
    public class SparseVector: Markable<SparseVector>
    {
        public const int ColCountOffset = 2;
        public const int ColumnsOffset = 4;

        internal SparseVector(byte[] sparseRecord, TableStructure structure, DataRecord parentRecord, short recordOffset)
        {
            Data = sparseRecord;
            Structure = structure;
            ParentRecord = parentRecord;
            RecordOffset = recordOffset;

            SparseVectorLoader.Load(this);
        }

        public static string GetComplexHeaderDescription(short complexVector)
        {
            switch (complexVector)
            {
                case 5:
                    return "In row sparse vector";
                default:
                    return "Unknown";
            }
        }

        internal TableStructure Structure { get; set; }

        public byte[] Data { get; set; }

        internal DataRecord ParentRecord { get; set; }

        public ushort[] Columns { get; set; }

        [Mark(MarkType.SparseColumns)]
        public string ColumnsDescription => Record<DataRecord>.GetArrayString(Columns);

        [Mark(MarkType.SparseColumnOffsets)]
        public string OffsetsDescription => Record<DataRecord>.GetArrayString(Offset);

        public ushort[] Offset { get; set; }

        [Mark(MarkType.SparseColumnCount)]
        public short ColCount { get; set; }

        public short RecordOffset { get; set; }

        public short ComplexHeader { get; set; }

        [Mark(MarkType.ComplexHeader)]
        public string ComplexHeaderDescription => GetComplexHeaderDescription(ComplexHeader);
    }
}
