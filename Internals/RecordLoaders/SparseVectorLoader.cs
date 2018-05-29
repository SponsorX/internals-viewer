﻿using System;
using InternalsViewer.Internals.Records;
using InternalsViewer.Internals.Structures;

namespace InternalsViewer.Internals.RecordLoaders
{
    class SparseVectorLoader
    {
        /// <summary>
        /// Loads a sparse vector.
        /// </summary>
        /// <param name="sparseVector">The sparse vector.</param>
        internal static void Load(SparseVector sparseVector)
        {
            var vectorOffset = sparseVector.ParentRecord.SlotOffset + sparseVector.RecordOffset;

            sparseVector.ComplexHeader = BitConverter.ToInt16(sparseVector.Data, 0);

            sparseVector.Mark(p => p.ComplexHeaderDescription, vectorOffset, sizeof(short));

            sparseVector.ColCount = BitConverter.ToInt16(sparseVector.Data, 2);

            sparseVector.Mark(p => p.ColCount, vectorOffset + SparseVector.ColCountOffset, sizeof(short));

            sparseVector.Columns = new ushort[sparseVector.ColCount];

            sparseVector.Mark(p => p.ColumnsDescription, vectorOffset + SparseVector.ColumnsOffset, sparseVector.ColCount * sizeof(short));

            sparseVector.Offset = new ushort[sparseVector.ColCount];

            sparseVector.Mark(p => p.OffsetsDescription,
                              vectorOffset + SparseVector.ColumnsOffset + sparseVector.ColCount * sizeof(short),
                              sparseVector.ColCount * sizeof(short));

            var previousOffset = 4 + (sparseVector.ColCount * 4);

            for (var i = 0; i < sparseVector.ColCount; i++)
            {
                sparseVector.Columns[i] = BitConverter.ToUInt16(sparseVector.Data, 4 + (i * 2));

                sparseVector.Offset[i] = BitConverter.ToUInt16(sparseVector.Data, (4 + sparseVector.ColCount * 2) + (i * 2));

                var columnData = new byte[sparseVector.Offset[i] - previousOffset];

                Array.Copy(sparseVector.Data, previousOffset, columnData, 0, sparseVector.Offset[i] - previousOffset);

                var column = sparseVector.Structure.Columns.Find(delegate(Column col) { return col.ColumnId == sparseVector.Columns[i]; });

                var field = new RecordField(column);

                field.Data = columnData;
                field.Sparse = true;
                field.Offset = sparseVector.Offset[i];
                field.Length = sparseVector.Offset[i] - previousOffset;

                field.Mark(p => p.Value, vectorOffset + previousOffset, field.Length);

                sparseVector.ParentRecord.Mark(p => p.FieldsArray, field.Name + " (Sparse)", sparseVector.ParentRecord.Fields.Count);

                previousOffset = sparseVector.Offset[i];
                sparseVector.ParentRecord.Fields.Add(field);

            }
        }
    }
}
