﻿using System;
using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Records;

namespace InternalsViewer.Internals.Compression
{
    public class DictionaryEntry : Markable<DictionaryEntry>
    {
        public DictionaryEntry(byte[] data)
        {
            Data = data;
        }

        [Mark(MarkType.Value)]
        public byte[] Data { get; set; }
    }
}
