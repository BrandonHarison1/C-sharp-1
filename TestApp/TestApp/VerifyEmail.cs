using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class VerifyEmail
    {
        public const string VALID_EMAIL = "Valid email";
        public const string INVALID_EMAIL = "Email is not valid";

        public string IsEmailValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return INVALID_EMAIL;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return VALID_EMAIL;
            }
            catch
            {
                return INVALID_EMAIL;

            }
        }
    }
}
