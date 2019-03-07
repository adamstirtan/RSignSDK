using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSignSDK.Tests
{
    [TestClass]
    public class MasterDataTests : BaseApiTest
    {
        [TestMethod]
        public void GetControlsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetControls();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetDateFormatsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetDateFormats();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetDropDownOptionsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetDropDownOptions();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetEnvelopeStatusesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetEnvelopeStatuses();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetEnvelopeTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetEnvelopeTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetExpiryTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetExpiryTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetFontsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetFonts();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetMailTemplatesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetMailTemplates();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetMaxCharactersTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetMaxCharacters();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetRecipientTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetRecipientTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetRSignStagesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetRSignStages();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetRuleConfigurationsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetRuleConfigurations();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetSettingsForTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetSettingsForTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetSettingsKeyConfigurationsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetSettingsKeyConfigurations();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetShowSettingsTabsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetShowSettingsTabs();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetSignatureFontsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetSignatureFonts();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetSignatureTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetSignatureTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetSignFontStylesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetSignFontStyles();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetStatusCodesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetStatusCodes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetTextTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetTextTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetTimeZonesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetTimeZones();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetUserConstantsTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetUserConstants();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetUserTypesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetUserTypes();

                    Assert.IsNotNull(list);
                    Assert.AreNotEqual(list.Count(), 0);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }
    }
}