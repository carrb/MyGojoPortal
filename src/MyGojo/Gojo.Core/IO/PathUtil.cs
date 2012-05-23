using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace Gojo.Core.IO
{
    public class PathUtil
    {
        public static string RelativePathTo(
            string fromDirectory, string toPath)
        {
            if (fromDirectory == null)
                throw new ArgumentNullException("fromDirectory");

            if (toPath == null)
                throw new ArgumentNullException("toPath");

            var isRooted = Path.IsPathRooted(fromDirectory) && Path.IsPathRooted(toPath);

            if (isRooted)
            {
                var isDifferentRoot = string.Compare(Path.GetPathRoot(fromDirectory), Path.GetPathRoot(toPath), StringComparison.InvariantCultureIgnoreCase) != 0;

                if (isDifferentRoot)
                    return toPath;
            }

            var relativePath = new List<String>();

            var fromDirectories = fromDirectory.Split(Path.DirectorySeparatorChar);

            var toDirectories = toPath.Split(Path.DirectorySeparatorChar);

            var length = Math.Min(fromDirectories.Length, toDirectories.Length);

            var lastCommonRoot = -1;

            // find common root
            for (var x = 0; x < length; x++)
            {
                if (string.Compare(fromDirectories[x], toDirectories[x], StringComparison.InvariantCultureIgnoreCase) != 0)
                    break;

                lastCommonRoot = x;
            }

            if (lastCommonRoot == -1)
                return toPath;

            // add relative folders in from path
            for (var x = lastCommonRoot + 1; x < fromDirectories.Length; x++)
                if (fromDirectories[x].Length > 0)
                    relativePath.Add("..");

            // add to folders to path
            for (var x = lastCommonRoot + 1; x < toDirectories.Length; x++)
                relativePath.Add(toDirectories[x]);

            // create relative path
            string[] relativeParts = new string[relativePath.Count];
            relativePath.CopyTo(relativeParts, 0);

            var newPath = string.Join(Path.DirectorySeparatorChar.ToString(), relativeParts);

            return newPath;
        }
    }
}
