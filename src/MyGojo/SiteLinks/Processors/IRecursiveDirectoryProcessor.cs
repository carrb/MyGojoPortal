using System.Collections.Generic;
using System.IO;

namespace SiteLinks.Processors
{
    public interface IRecursiveDirectoryProcessor
    {
        IDictionary<string, string> CollectedFileEntries { get; }
        void WalkDirectoryTree(DirectoryInfo dirInfo);
    }
}