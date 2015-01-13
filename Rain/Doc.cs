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
        public List<Rain.Part> parts;
        public Rain.Part currentPart;

        /// <summary>
        /// Creates a new doc object based on a file's
        /// path and its contents. The doc object is used
        /// to parse and compile doc parts.
        /// </summary>
        /// <param name="fileName">The name and path of the file to parse.</param>
        /// <param name="fileContents">The contents of the file to parse.</param>
        public Doc(string fileName, string fileContents)
        {
            this.fileName = fileName;
            this.fileContents = fileContents;

            this.parser = new Rain.Parser();
            this.parts = new List<Part>();

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

        /// <summary>
        /// Adds a new docpart to the list. Uses the current
        /// part if it is not null, then sets the current
        /// part to a new part.
        /// </summary>
        public void AddPart()
        {
            if (this.currentPart != null)
                this.parts.Add(this.currentPart);

            this.currentPart = new Part();
        }

        public enum Type
        {
            MARKDOWN,
            CSHARP,
            VISUALBASIC
        }
    }
}
