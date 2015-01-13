using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rain
{
    class Program
    {
        static void Main(string[] args)
        {

            // Loop through all of the source files.
            for (var i = 0; i < args.Length; i++)
            {
                string currentFileContents = File.ReadAllText(args[0]);

                Rain.Doc doc = new Rain.Doc("file_name.txt", currentFileContents);
            };
        }
    }
}
