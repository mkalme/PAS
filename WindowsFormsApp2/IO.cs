using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    class IO
    {
        public static void createFile(string name, string text, string path, bool state) {
            try
            {
                using (StreamWriter newTask = new StreamWriter(path + @"\" + name, state))
                {
                    newTask.WriteLine(text);
                }
            }
            catch {

            }
        }

        public static string readFile(string path, bool readFirstLine)
        {
            string lines = "";
            try
            {
                if (readFirstLine)
                {
                    lines = File.ReadLines(path).First();
                }
                else {
                    lines = File.ReadLines(path).ElementAtOrDefault(1);
                }
            }
            catch
            {

            }

            return lines;
        }

        public static string deleteFile(string path)
        {
            string lines = "";
            try
            {
            File.Delete(path);
            }
            catch
            {

            }

            return lines;
        }
    }
}
