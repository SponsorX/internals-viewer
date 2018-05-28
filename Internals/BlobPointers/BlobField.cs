﻿using System.Collections.ObjectModel;
using System.Text;
using System;
using System.Collections.Generic;
using InternalsViewer.Internals.Records;

namespace InternalsViewer.Internals.BlobPointers
{
    /// <summary>
    /// BLOB internal field
    /// </summary>
    public abstract class BlobField : Field
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobField"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public BlobField(byte[] data, int offset)
        {
            Data = data;
            PointerType = (BlobFieldType)data[0];
            Offset = offset;

            Mark("PointerType", offset, sizeof(byte));

            LoadLinks();
        }

        /// <summary>
        /// Gets or sets the timestamp used by DBCC CHECKTABLE
        /// </summary>
        /// <value>The timestamp.</value>
        [MarkAttribute("Timestamp", "DarkGreen", "PeachPuff", true)]
        public int Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>The links.</value>
        public List<BlobChildLink> Links { get; set; }

        [MarkAttribute("Row Id", "Blue", "PeachPuff", true)]
        public BlobChildLink[] LinksArray
        {
            get { return Links.ToArray(); }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the type of the blob pointer.
        /// </summary>
        /// <value>The type of the blob pointer.</value>
        [MarkAttribute("Type", "DarkGreen", "PeachPuff", true)]
        public BlobFieldType PointerType { get; set; }

        /// <summary>
        /// Gets or sets the offset in the page for this blob field
        /// </summary>
        /// <value>The offset.</value>
        public int Offset { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Timestamp.ToString());

            foreach (var b in Links)
            {
                sb.AppendLine(b.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Loads the links.
        /// </summary>
        protected virtual void LoadLinks()
        {
        }
    }
}
