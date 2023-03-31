namespace TestApp.Test
{
    [TestClass]
    public class GetEmailMessage
    {
        [TestMethod]
        public void Return_Invalid_Email_When_Email_Has_No_At_Sign()
        {
            // Arrange
            var VerifyEmail = new VerifyEmail();
            var email = "correodeprueba.com";

            // Act
            var message = VerifyEmail.IsEmailValid(email);

            // Assert
            Assert.AreEqual(message, VerifyEmail.INVALID_EMAIL);
        }

        [TestMethod]
        public void Return_Invalid_Email_When_Email_Ends_With_Dot()
        {
            // Arrange
            var VerifyEmail = new VerifyEmail();
            var email = "correodeprueba@correo.";

            // Act
            var message = VerifyEmail.IsEmailValid(email);

            // Assert
            Assert.AreEqual(message, VerifyEmail.INVALID_EMAIL);
        }

        [TestMethod]
        public void Return_Valid_Email_When_Email_Is_Valid()
        {
            // Arrange
            var VerifyEmail = new VerifyEmail();
            var email = "correodeprueba@correo.com";

            // Act
            var message = VerifyEmail.IsEmailValid(email);

            // Assert
            Assert.AreEqual(message, VerifyEmail.VALID_EMAIL);
        }
    }
}