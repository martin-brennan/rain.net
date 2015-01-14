using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rain.Test
{
    [TestClass]
    public class PartTest
    {
        public Rain.Part part;

        [TestInitialize]
        public void Initialize()
        {
            this.part = new Rain.Part();
        }

        [TestMethod]
        public void ItInitializesWithDefaultValues()
        {
            Assert.AreEqual(null, part.HttpMethod);
            Assert.AreEqual(0, part.Responses.Count);
            Assert.AreEqual(0, part.Docs.Count);
            Assert.AreEqual(null, part.Route);
            Assert.AreEqual(0, part.Headers.Count);
            Assert.AreEqual(0, part.Parameters.Count);
        }

        [TestMethod]
        public void ItCanAppendDocsToTheSpecifiedResponseCode()
        {
            part.AppendResponse(200, "success", "{");
            part.AppendResponse(200, "success", "  id: 1490");
            part.AppendResponse(200, "success", "}");
            Assert.AreEqual("{  id: 1490}", part.GetResponse(200, "success").Replace("\n", ""));
        }
    }
}
