using MediaBazaar_ManagementSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTests_Logic
    {
        [TestMethod, TestCategory("Hashing")]
        public void EncryptTest()
        {
            string test = "pQxRfGeDak8c272k95JV3qaG";
            string control = "2AB52B36481D1A50EB767E69A8D1331673BFB3A97680E6EB2E5869D113607E890A288C054175E075F58FE82E2A4EA1F3FFAAF96D6AC20EE506725B673E4331CD";

            string hashed = Encrypt.Run(test);

            Assert.AreEqual(control, hashed);
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExNameTest()
        {
            string pass = "Max";
            string fail = "1max";

            Assert.IsTrue(CheckValidity.Name(pass));
            Assert.IsFalse(CheckValidity.Name(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExEmailTest()
        {
            string pass = "max@mpfg.nl";
            string fail = "max";

            Assert.IsTrue(CheckValidity.Email(pass));
            Assert.IsFalse(CheckValidity.Email(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExPhoneNumberTest()
        {
            string pass = "+31612345678";
            string pass2 = "0612345678";
            string fail = "0612345";

            Assert.IsTrue(CheckValidity.PhoneNumber(pass));
            Assert.IsTrue(CheckValidity.PhoneNumber(pass));
            Assert.IsFalse(CheckValidity.PhoneNumber(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExUsernameTest()
        {
            string pass = "glaser.m";
            string fail = "";

            Assert.IsTrue(CheckValidity.Username(pass));
            Assert.IsFalse(CheckValidity.Username(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExPasswordTest()
        {
            string pass = "Password123!";
            string fail = "password";

            Assert.IsTrue(CheckValidity.Password(pass));
            Assert.IsFalse(CheckValidity.Password(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExAddressTest()
        {
            string pass = "De Straat 1";
            string pass2 = "Straat 100";
            string pass3 = "Straatlaandreef 3956B";
            string fail = "Straat";

            Assert.IsTrue(CheckValidity.Address(pass));
            Assert.IsTrue(CheckValidity.Address(pass2));
            Assert.IsTrue(CheckValidity.Address(pass3));
            Assert.IsFalse(CheckValidity.Address(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExPostalCodeTest()
        {
            string pass = "1234AB";
            string pass2 = "1234 AB";
            string fail = "12ab";

            Assert.IsTrue(CheckValidity.PostalCode(pass));
            Assert.IsTrue(CheckValidity.PostalCode(pass2));
            Assert.IsFalse(CheckValidity.PostalCode(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExBSNTest()
        {
            string pass = "123456789";
            string fail = "12345678";
            string fail2 = "1234567890";

            Assert.IsTrue(CheckValidity.BSN(pass));
            Assert.IsFalse(CheckValidity.BSN(fail));
            Assert.IsFalse(CheckValidity.BSN(fail2));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExNumbersOnlyTest()
        {
            string pass = "35643513";
            string fail = "sakhbdfe45454";

            Assert.IsTrue(CheckValidity.NumbersOnly(pass));
            Assert.IsFalse(CheckValidity.NumbersOnly(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExStandardInputTest()
        {
            string pass = "test";
            string fail = " ";

            Assert.IsTrue(CheckValidity.StandardInput(pass));
            Assert.IsFalse(CheckValidity.StandardInput(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExCategoryTest()
        {
            string pass = "Computers";
            string fail = "134Computers";

            Assert.IsTrue(CheckValidity.Category(pass));
            Assert.IsFalse(CheckValidity.Category(fail));
        }

        [TestMethod, TestCategory("RegEx")]
        public void RegExProductCodeTest()
        {
            string pass = "12345465";
            string fail = "123";

            Assert.IsTrue(CheckValidity.ProductCode(pass));
            Assert.IsFalse(CheckValidity.ProductCode(fail));
        }
    }
}