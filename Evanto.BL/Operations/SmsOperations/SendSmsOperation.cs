using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.SmsOperations
{
    public class SendSmsOperation : Operation<SendSmsInput, SendSmsOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            SendSmsOutput output = new SendSmsOutput();

            var sentSms = new SmsQueue()
            {
                TypeId = Parameters.TypeId,
                StatusId = (int) SmsStatusValue.NotSent,
                Recipient = Parameters.Recipient,
                Text = Parameters.Text
            };


            var url = "http://sendsms.az/index.php?app=quick_sms&login={0}&msisdn={1}&text={2}&sender={3}&key={4}";
            string requestUrl = string.Format(
               url,
                 ConfigHelper.GetAppSetting("SMSLogin") , Parameters.Recipient,Uri.EscapeUriString(Parameters.Text) ,
                   ConfigHelper.GetAppSetting("SMSSender") ,CHashing.GetMd5HashData( CHashing.GetMd5HashData(ConfigHelper.GetAppSetting("SMSPassword")) + ConfigHelper.GetAppSetting("SMSLogin")
                                            + Parameters.Text
                                            + Parameters.Recipient
                                            + ConfigHelper.GetAppSetting("SMSSender") ));
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(requestUrl));
                request.Accept = "*/*";
                request.Method = "GET";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Result.ErrorList.Add(new Error
                    {
                        Type = OperationResultCode.Error,
                        Code = response.StatusCode.ToString(),
                        Text = response.StatusDescription
                    });

                    SetSmsStatusAsFailed(sentSms, response.StatusCode.ToString(), response.StatusDescription);

                    output.IsSent = false;
                    Result.Output = output;
                    return;
                }

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        int result;
                        if (!int.TryParse(content, out result))
                        {
                            Result.ErrorList.Add(new Error
                            {
                                Type = OperationResultCode.Error,
                                Code = response.StatusCode.ToString(),
                                Text = content
                            });

                            SetSmsStatusAsFailed(sentSms, response.StatusCode.ToString(), content);

                            output.IsSent = false;
                            Result.Output = output;
                            return;
                        }
                        else if (result <= 0)
                        {
                            Result.ErrorList.Add(new Error
                            {
                                Type = OperationResultCode.Error,
                                Code = response.StatusCode.ToString(),
                                Text = content
                            });

                            SetSmsStatusAsFailed(sentSms, response.StatusCode.ToString(), content);

                            output.IsSent = false;
                            Result.Output = output;
                            return;
                        }
                    }
                }
            }
            catch (WebException wex)
            {

                var response = wex.Response as HttpWebResponse;
                if (response != null)
                {
                    Result.ErrorList.Add(new Error
                            {
                                Type = OperationResultCode.Error,
                                Code = response.StatusCode.ToString(),
                                Text = response.StatusDescription
                            });

                    SetSmsStatusAsFailed(sentSms, response.StatusCode.ToString(), response.StatusDescription);

                    output.IsSent = false;
                    Result.Output = output;
                    return;
                }
                else
                {
                    while (wex.InnerException != null)
                        wex = (WebException) wex.InnerException;
                   
                    Result.ErrorList.Add(new Error()
                    {
                        Type = OperationResultCode.Exception,
                        Code = "SystemError",
                        Text = "An unhandled error occured"
                    });
                }
                SetSmsStatusAsFailed(sentSms);

                output.IsSent = false;
                Result.Output = output;
                return;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Exception,
                    Code = "SystemError",
                    Text = "An unhandled error occured"
                });

                SetSmsStatusAsFailed(sentSms);

                output.IsSent = false;
                Result.Output = output;
                return;
            }

            sentSms.SentDate = DateTime.UtcNow.AddHours(4);
            sentSms.StatusId = (int)SmsStatusValue.Sent;

            Uow.GetRepository<SmsQueue>().Add(sentSms);
            Uow.SaveChanges();

            output.IsSent = true;
            Result.Output = output;
        }

        private void SetSmsStatusAsFailed(SmsQueue sms, string requestStatusCode = null, string responseContent = null)
        {
            sms.StatusId = (int)SmsStatusValue.NotSent;
            sms.Description = (requestStatusCode != null && responseContent != null) ? $"{requestStatusCode}, {responseContent}" : null;

            Uow.GetRepository<SmsQueue>().Add(sms);
            Uow.SaveChanges();
        }
    }
}
