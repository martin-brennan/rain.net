using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rain.Test
{
    [TestClass]
    public class DocTest
    {
        private Rain.Doc doc;

        [TestInitialize]
        public void Initialize()
        {
            doc = new Rain.Doc("file_test.txt", "This is the contents of the file.");
        }

        [TestMethod]
        public void ItShouldInitializeWithARainParser()
        {
            Assert.IsTrue(doc.parser is Rain.Parser);
        }

        [TestMethod]
        public void ItShouldSetTheTitleToTheFileNameWithoutSymbols()
        {
            Assert.AreEqual("File Test", doc.title);
        }

        [TestMethod]
        public void ItShouldSetTheFileExtensionAndType()
        {
            Assert.AreEqual(doc.fileExt, ".txt");
            Assert.AreEqual(doc.type, Rain.Doc.Type.MARKDOWN);

            Rain.Doc doc2 = new Rain.Doc("testfile.cs", "private string test;");
            Assert.AreEqual(doc2.fileExt, ".cs");
            Assert.AreEqual(doc2.type, Rain.Doc.Type.CSHARP);
        }
    }
}
