using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TamAnhHRM.UnitTest
{
    [TestFixture]
    class LoginTest
    {
        [TestCase("18a10010004@students.hou.edu.vn")]
        public void validEmail(string email)
        {
            Assert.True(Utilities.isValidEmail(email));
        }

        [TestCase("18a10010004")]
        [TestCase("' or 1=1 --@gmail.com")]
        [TestCase("###@gmail.com")]
        [TestCase("a@g")]
        public void invalidEmail(string email)
        {
            Assert.False(Utilities.isValidEmail(email));
        }

        [TestCase("number_1")]
        public void test_HasNumber(string str)
        {
            Assert.True(Utilities.hasNumber(str));
        }

        [TestCase("nonumber")]
        public void test_HasNoNumber(string str)
        {
            Assert.False(Utilities.hasNumber(str));
        }

        [TestCase("morethaneightchars")]
        [TestCase("8charsss")]
        public void test_HasMinimum8Chars(string str)
        {
            Assert.True(Utilities.hasMinimum8Chars(str));
        }

        [TestCase("<8chars")]
        public void test_DoNotHasMinimum8Chars(string str)
        {
            Assert.False(Utilities.hasMinimum8Chars(str));
        }

        [TestCase("UPPERCASE")]
        [TestCase("sOmeStrInG")]
        public void test_HasUpperChar(string str)
        {
            Assert.True(Utilities.hasUpperChar(str));
        }

        [TestCase("lowercase")]
        public void test_HasNoUpperChar(string str)
        {
            Assert.False(Utilities.hasUpperChar(str));
        }
    }
}
