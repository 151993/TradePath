using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_TradePath_Amol
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = { };
            string[] directory;
            string path = @"D:\CSharpTest\InputDirectory";
            string destpath = @"D:\CSharpTest\OutputDirectory";
            if (Directory.Exists(path))
            {
                directory = Directory.GetDirectories(path);
                foreach (var item in directory)
                {
                    path= item;
                    files = Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories);

                    string pathString = System.IO.Path.Combine(destpath, Guid.NewGuid().ToString());

                    // You can write out the path name directly instead of using the Combine
                    // method. Combine just makes the process easier.
                   // string pathString2 = @"c:\Top-Level Folder\SubFolder2";

                    var dir = Directory.CreateDirectory(pathString);
                    string compath = Path.Combine(destpath, dir.FullName);
                    string temp =Path.Combine(compath, "MergeFiles.csv");
                    using (var output = File.Create(temp))
                    {
                        foreach (var file in files)
                        {
                            using (var data = File.OpenRead(file))
                            {
                                data.CopyTo(output);
                            }
                        }
                    }
                }
                
            }
          
        }
    }
}
