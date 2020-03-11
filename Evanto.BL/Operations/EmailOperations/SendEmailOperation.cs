using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using Evanto.Security;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.EmailOperations
{
    public class SendEmailOperation : Operation<SendEmailInput, SendEmailOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            SendEmailOutput output=new SendEmailOutput();

            var message = new MailMessage();
            message.To.Add(new MailAddress(Parameters.Recipient));

            message.From = EmailAddressHelper.GetEmailAddress(Parameters.EmailType);
            message.Subject = Parameters.Subject;
            message.Body = Parameters.Content;

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(EmailAddressHelper.GetEmailAddress(Parameters.EmailType).Address, "C#dVls14aTx#4Nh$yUHD@g&EFeKL1d"),
                    EnableSsl = true
                })

                {
                    smtp.Send(message);
                }

                output.IsSent = true;
            }
            catch (Exception e)
            {
                Logger.Error("Email could not be sent", e);

                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Exception,
                    Text = "Email could not be sent",
                    Code = "EmailNotSent"
                });
                output.IsSent = false;
            }

            Result.Output = output;
        }
    }
}
