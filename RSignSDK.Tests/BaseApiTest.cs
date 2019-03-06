using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using RSignSDK.Models.Authentication;

namespace RSignSDK.Tests
{
    public abstract class BaseApiTest
    {
        protected RSignAPICredentials GetCredentials()
        {
            var configurationFilePath = Path.Combine(
                Environment.CurrentDirectory, "..", "..", "credentials.json");

            if (!File.Exists(configurationFilePath))
            {
                Assert.Fail("Could not find credentials.json");
            }

            using (var streamReader = new StreamReader(configurationFilePath))
            {
                return JsonConvert.DeserializeObject<RSignAPICredentials>(streamReader.ReadToEnd());
            }
        }
    }
}