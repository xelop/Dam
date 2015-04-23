using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Dam.Logic
{
    static class FileManagement
    {
        public static void addToFile(string pExceptionMessage)
        {
            string path = "Exception.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(pExceptionMessage);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(pExceptionMessage);
                tw.Close();
            }
        }
    }
}
