using System;
using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Records;
using InternalsViewer.Internals.BlobPointers;
using System.Collections;
using InternalsViewer.Internals.Pages;

namespace InternalsViewer.Internals.RecordLoaders
{
    class BlobRecordLoader : RecordLoader
    {
        /// <summary>
        /// Loads the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        internal static void Load(BlobRecord record)
        {
            var statusByte = record.Page.PageData[record.SlotOffset];

            record.Mark(p => p.StatusBitsADescription, record.SlotOffset, sizeof(byte));

            record.StatusBitsA = new BitArray(new byte[] { statusByte });

            record.Mark(p => p.StatusBitsBDescription, record.SlotOffset + sizeof(byte), sizeof(byte));

            record.RecordType = (RecordType)((statusByte >> 1) & 7);

            record.Mark(p => p.Length, record.SlotOffset + BlobRecord.LengthOffset, sizeof(short));

            record.Length = BitConverter.ToInt16(record.Page.PageData, record.SlotOffset + BlobRecord.LengthOffset);

            record.Mark(p => p.BlobId, record.SlotOffset + BlobRecord.IdOffset, sizeof(long));

            record.BlobId = BitConverter.ToInt64(record.Page.PageData, record.SlotOffset + BlobRecord.IdOffset);

            record.Mark(p => p.BlobTypeDescription, record.SlotOffset + BlobRecord.TypeOffset, sizeof(short));

            record.BlobType = (BlobType)record.Page.PageData[record.SlotOffset + BlobRecord.TypeOffset];

            switch (record.BlobType)
            {
                case BlobType.LargeRoot:
                case BlobType.Internal:

                    LoadLargeRoot(record);
                    break;

                case BlobType.SmallRoot:

                    LoadSmallRoot(record);
                    break;

                case BlobType.Data:

                    LoadData(record);
                    break;
            }
        }

        private static void LoadLargeRoot(BlobRecord record)
        {
            BlobChildLink link;
            record.BlobChildren = new List<BlobChildLink>();

            record.Mark(p => p.MaxLinks, record.SlotOffset + BlobRecord.MaxLinksOffset, sizeof(short));

            record.MaxLinks = BitConverter.ToInt16(record.Page.PageData, record.SlotOffset + BlobRecord.MaxLinksOffset);

            record.Mark(p => p.CurLinks, record.SlotOffset + BlobRecord.CurLinksOffset, sizeof(short));

            record.CurLinks = BitConverter.ToInt16(record.Page.PageData, record.SlotOffset + BlobRecord.CurLinksOffset);

            record.Mark(p => p.Level, record.SlotOffset + BlobRecord.RootLevelOffset, sizeof(short));

            record.Level = BitConverter.ToInt16(record.Page.PageData, record.SlotOffset + BlobRecord.RootLevelOffset);

            for (var i = 0; i < record.CurLinks; i++)
            {
                record.Mark(p => p.BlobChildrenArray, "Child " + i.ToString() + " ", i);

                if (record.BlobType == BlobType.LargeRoot)
                {
                    link = LoadRootBlobChild(record, i);
                }
                else
                {
                    link = LoadInternalBlobChild(record, i);
                }

                record.BlobChildren.Add(link);
            }
        }

        private static void LoadSmallRoot(BlobRecord record)
        {
            record.Mark(p => p.Size, record.SlotOffset + BlobRecord.MaxLinksOffset, sizeof(short));

            record.Size = BitConverter.ToInt16(record.Page.PageData, record.SlotOffset + BlobRecord.MaxLinksOffset);

            record.Data = new byte[record.Size];

            record.Mark(p => p.Data, record.SlotOffset + BlobRecord.SmallDataOffset, record.Size);

            Array.Copy(record.Page.PageData,
                       record.SlotOffset + BlobRecord.SmallDataOffset,
                       record.Data,
                       0,
                       record.Size);
        }

        private static void LoadData(BlobRecord blobRecord)
        {
            blobRecord.Mark(p => p.Data, blobRecord.SlotOffset + BlobRecord.DataOffset, blobRecord.Length);

            blobRecord.Data = new byte[blobRecord.Length];

            Array.Copy(blobRecord.Page.PageData,
                       blobRecord.SlotOffset + BlobRecord.DataOffset,
                       blobRecord.Data,
                       0,
                       blobRecord.Length);
        }

        private static BlobChildLink LoadInternalBlobChild(BlobRecord blobRecord, int index)
        {
            var offset = BitConverter.ToInt32(blobRecord.Page.PageData,
                                              blobRecord.SlotOffset + BlobRecord.InternalChildOffset + (index * 16));

            var rowData = new byte[8];

            Array.Copy(blobRecord.Page.PageData,
                       blobRecord.SlotOffset + BlobRecord.InternalChildOffset + (index * 16) + 8,
                       rowData,
                       0,
                       8);

            var rowId = new RowIdentifier(rowData);

            return new BlobChildLink(rowId, offset, offset);
        }

        private static BlobChildLink LoadRootBlobChild(BlobRecord record, int index)
        {
            var blobChildLink = new BlobChildLink();

            var offsetPosition =  record.SlotOffset + BlobRecord.RootChildOffset + (index * 12);

            blobChildLink.Mark(p => p.Offset, offsetPosition, sizeof(int));

            var offset = BitConverter.ToInt32(record.Page.PageData, offsetPosition);

            var rowData = new byte[8];

            var rowIdPosition = record.SlotOffset + BlobRecord.RootChildOffset + (index * 12) + 4;

            blobChildLink.Mark(p => p.RowIdentifier, rowIdPosition, 8);

            Array.Copy(record.Page.PageData, rowIdPosition, rowData, 0, 8);

            var rowId = new RowIdentifier(rowData);

            blobChildLink.RowIdentifier = rowId;
            blobChildLink.Offset = offset;

            return blobChildLink;
        }
    }
}
