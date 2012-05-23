using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace SiteLinks.Processors
{
    public class RecursiveDirectoryProcessor
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        

        ///  Constructor
        public RecursiveDirectoryProcessor(string fileSystemLocation)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fileSystemLocation);

            logger.Info("RecursiveDirectoryProcessor working...");
            WalkDirectoryTree(dirInfo);
            logger.Info("...processing complete.");
        }


        public void WalkDirectoryTree(DirectoryInfo dirInfo)
        {
            FileInfo[] files = null;

            try
            {
                files = dirInfo.GetFiles("*.*");
            }   
            catch (UnauthorizedAccessException ex)
            {
                logger.Error("Access denied: {0}", ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error("File system location not found: {0}", ex.Message);
            }

            if (files == null) return;

            foreach (FileInfo fileInfo in files.Where(fileInfo => !App.CollectedFileEntries.ContainsKey(fileInfo.FullName)))
            {
                App.CollectedFileEntries.Add(fileInfo.FullName, dirInfo.FullName);
            }

            DirectoryInfo[] subDirs = dirInfo.GetDirectories();
            
            foreach (DirectoryInfo subDirInfo in subDirs)
            {
                WalkDirectoryTree(subDirInfo);    
            }
        }


    }
}
