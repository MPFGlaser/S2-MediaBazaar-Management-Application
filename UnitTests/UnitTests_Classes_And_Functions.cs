using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MediaBazaar_ManagementSystem;
using System.Text;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTests_Classes_And_Functions
    {
        [TestMethod, TestCategory("Hashing")]
        public void EncryptTest()
        {
            string test = "pQxRfGeDak8c272k95JV3qaG";
            string control = "2AB52B36481D1A50EB767E69A8D1331673BFB3A97680E6EB2E5869D113607E890A288C054175E075F58FE82E2A4EA1F3FFAAF96D6AC20EE506725B673E4331CD";

            string hashed = Encrypt.Run(test);

            Assert.AreEqual(control, hashed);
        }
    }
}
