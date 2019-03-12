using Microsoft.VisualStudio.TestTools.UnitTesting;

using RSignSDK.Extensions;
using RSignSDK.Models;

namespace RSignSDK.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void EnumExtensionsTest()
        {
            const string actual = "de-de";

            var language = RSignLanguage.German;

            var sut = language.GetDescription();

            Assert.AreEqual(sut, actual);
        }
    }
}