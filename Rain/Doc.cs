using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    public class Doc
    {
        private string fileName;
        private string fileContents;
        public string fileExt;
        public Type type;
        public Rain.Parser parser;
        public string title;

        public Doc(string fileName, string fileContents)
        {
            this.fileName = fileName;
            this.fileContents = fileContents;

            this.parser = new Rain.Parser();

            // Remove any symbols or charactes, as well as the extension and convert
            // to title case.
            this.title = System.IO.Path.GetFileNameWithoutExtension(fileName);
            this.title = this.title.Replace("_", " ").Replace("-", " ");
            this.title = Rain.Util.ToTitleCase(this.title);

            // Set the file extension and the type based on the extension.
            this.fileExt = System.IO.Path.GetExtension(fileName);
            switch (this.fileExt)
            {
                case ".txt":
                case ".md":
                case ".mdown":
                case ".markdown":
                    this.type = Type.MARKDOWN;
                    break;
                case ".vb":
                    this.type = Type.VISUALBASIC;
                    break;
                case ".cs":
                    this.type = Type.CSHARP;
                    break;
            }
        }

        public enum Type
        {
            MARKDOWN,
            CSHARP,
            VISUALBASIC
        }
    }
}
