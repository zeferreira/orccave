using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
        public class FileSystemHelper  
        {
            public long GetFileSize(string fileName)
            {
                FileInfo fileInfo = new FileInfo(fileName);

                return fileInfo.Length;
            }

            public string GetExtension(string fileName)
            {
                FileInfo fileInfo = new FileInfo(fileName);

                return fileInfo.Extension;
            }

            public DateTime GetCreationDate(string fileName)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                DateTime result;

                if (fileInfo.LastWriteTime < fileInfo.CreationTime)
                {
                    result = fileInfo.LastWriteTime;
                }
                else
                {
                    result = fileInfo.CreationTime;
                }

                return result;
            }

            public string[] GetFiles(string directoryName)
            {
                return Directory.GetFiles(directoryName);
            }

            public  List<string> ReadFiles(string path)
            {
                List<string> files = new List<string>();

                FileSystemHelper fileHelper = new FileSystemHelper();
                //folder
                string[] tmpFiles = fileHelper.GetFiles(path);

                foreach (var item in tmpFiles)
                {
                    files.Add(item);
                }

                return files;
            }

    }
}


