using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rain.Test
{
    /// <summary>
    /// Summary description for UtilTest
    /// </summary>
    [TestClass]
    public class UtilTest
    {

        [TestMethod]
        public void ItConvertsAStringsWordsToTitleCase()
        {
            Assert.AreEqual("Test Word", Rain.Util.ToTitleCase("test word"));
            Assert.AreEqual("Hello, World!", Rain.Util.ToTitleCase("hello, world!"));
            Assert.AreEqual("This Is A SENTENCE", Rain.Util.ToTitleCase("this is a SENTENCE"));
        }
    }
}
