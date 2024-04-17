using Registration;

namespace RegistrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCheckUsernamePositive()
        {
            bool valueActual = RegistrationClass.checkUsername("test123");
            Assert.AreEqual(true, valueActual);

            valueActual = RegistrationClass.checkUsername("qhqwhqwh");
            Assert.AreEqual(false, valueActual);
        }

        [TestMethod]
        public void TestCheckUsernameNegative()
        {
            bool valueActual = RegistrationClass.checkUsername("sdasdsad");
            Assert.AreEqual(true, valueActual);

            valueActual = RegistrationClass.checkUsername("test321");
            Assert.AreEqual(false, valueActual);
        }

        [TestMethod]
        public void TestCheckPasswordPositif()
        {
            bool valueActual = RegistrationClass.checkPassword("sdasdsada");
            Assert.AreEqual(true, valueActual);

            valueActual = RegistrationClass.checkUsername("t321");
            Assert.AreEqual(false, valueActual);
        }

        [TestMethod]
        public void TestCheckPasswordNegitif()
        {
            bool valueActual = RegistrationClass.checkPassword("s");
            Assert.AreEqual(true, valueActual);

            valueActual = RegistrationClass.checkUsername("t321adsasddas");
            Assert.AreEqual(false, valueActual);
        }
    }
}