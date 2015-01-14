using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rain.Test
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void ItInitializesConfigWithDefaultValues()
        {
            Assert.AreEqual("img/logo.png", Rain.Config.Globals.HeaderImageUrl);
            Assert.AreEqual("Rain API Documentation", Rain.Config.Globals.ApiTitle);
            Assert.AreEqual("http://www.martin-brennan.github.io/rain", Rain.Config.Globals.ApiUrl);
            Assert.AreEqual("0.0.1", Rain.Config.Globals.ApiVersion);
            Assert.AreEqual("https://github.com/martin-brennan/rain", Rain.Config.Globals.SourceUrl);
            Assert.AreEqual("Rain", Rain.Config.Globals.CompanyName);
        }
    }
}
