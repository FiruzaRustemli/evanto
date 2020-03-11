using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Evanto.Utils.Enums;

namespace Evanto.Utils
{
    public static class EmailAddressHelper
    {
        public static MailAddress GetEmailAddress(EmailType emailType)
        {
            if (emailType == EmailType.ResetPassword || emailType == EmailType.Verification)
            {
                return new MailAddress("noreply.brono@gmail.com");
            }
            throw new Exception("No email adress for this type of email.");
        }
    }
}
