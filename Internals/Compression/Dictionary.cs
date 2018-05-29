using System;
using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Records;

namespace InternalsViewer.Internals.Compression
{
    public class Dictionary : Markable<Dictionary>
    {
        public Dictionary(byte[] data, int offset)
        {
            Offset = offset;
            LoadDictionary(data, offset);
        }

        private void LoadDictionary(byte[] data, int offset)
        {
            EntryCount = BitConverter.ToInt16(data, offset);

            Mark(p => p.EntryCount, offset, sizeof(short));

            EntryOffset = new ushort[EntryCount];

            var dataOffset = sizeof(short) + (sizeof(short) * EntryCount);

            Mark(p => p.EntryOffsetArrayDescription, offset + sizeof(short), EntryCount * sizeof(short));

            for (var i = 0; i < EntryCount; i++)
            {
                EntryOffset[i] = BitConverter.ToUInt16(data, offset + sizeof(short) + (sizeof(short) * i));

                var length = EntryOffset[i] - dataOffset;

                var dictionaryData = new byte[length];

                Array.Copy(data, offset + dataOffset, dictionaryData, 0, length);

                Mark(p => p.DictionaryEntries, "Dictionary Entry " + i, i);

                var entry = new DictionaryEntry(dictionaryData);

                entry.Mark(p => p.Data, offset + dataOffset, length);

                DictionaryEntries.Add(entry);

                dataOffset = EntryOffset[i];
            }
        }

        public int Offset { get; set; }

        public List<DictionaryEntry> DictionaryEntries { get; set; } = new List<DictionaryEntry>();

        [Mark(MarkType.EntryCount)]
        public int EntryCount { get; set; }

        public ushort[] EntryOffset { get; set; }

        [Mark(MarkType.ColumnOffsetArray)]
        public string EntryOffsetArrayDescription => DataRecord.GetArrayString(EntryOffset);
    }
}
