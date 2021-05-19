using System.Net.Mail;

namespace BLL.Services
{
    static class EmailHelper
    {
        public static bool Validate(string email)
        {
            MailAddress address = new MailAddress(email);
            bool isEmailValid = (address.Address == email);
            return isEmailValid;
        }
    }
}

