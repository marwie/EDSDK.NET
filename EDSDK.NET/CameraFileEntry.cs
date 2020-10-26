using System;
using System.Collections.Generic;
// using System.Drawing;
using System.Text;

namespace EDSDK.NET
{
    /// <summary>
    /// A storage for a camera filesystem entry
    /// </summary>
    public class CameraFileEntry
    {
        /// <summary>
        /// Name of this entry
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// States if this entry is a folder or not
        /// </summary>
        public bool IsFolder { get; private set; }
        /// <summary>
        /// <summary>
        /// Subentries of this entry (i.e. subfolders)
        /// </summary>
        public CameraFileEntry[] Entries { get; private set; }

        /// <summary>
        /// Creates a new instance of the CameraFileEntry class
        /// </summary>
        /// <param name="Name">Name of this entry</param>
        /// <param name="IsFolder">True if this entry is a folder, false otherwise</param>
        public CameraFileEntry(string Name, bool IsFolder)
        {
            this.Name = Name;
            this.IsFolder = IsFolder;
        }

        /// <summary>
        /// Adds subentries (subfolders) to this entry
        /// </summary>
        /// <param name="Entries">the entries to add</param>
        public void AddSubEntries(CameraFileEntry[] Entries)
        {
            this.Entries = Entries;
        }
    }
}
