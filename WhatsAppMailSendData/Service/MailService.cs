using System.Net.Mail;
using WhatsAppMailSendData.Model;

namespace WhatsAppMailSendData.Service
{
    public class MailService
    {
        public static void Send2(SendMail mModel)
        {
            try
            {
                string SendFrom = "mohan.baghel@ajeevi.com";
                string SendPassword = "Pokemon@#32189";
                string Body = mModel.MailBody;
                MailAddress From = new MailAddress(SendFrom);
                MailAddress To = new MailAddress(mModel.CustomerEmail);
                MailMessage MyMessage = new MailMessage(From, To);
                MyMessage.IsBodyHtml = true;
                MyMessage.Subject = mModel.MailSubject;// "Waredot Total Security mail verification code";
                MyMessage.Body = Body;
                SmtpClient emailClient = new SmtpClient("smtp.hostinger.com", 587);
                System.Net.NetworkCredential NTLMAuthentication = new System.Net.NetworkCredential(SendFrom, SendPassword);
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = NTLMAuthentication;
                emailClient.EnableSsl = true;
                emailClient.Send(MyMessage);
            }
            catch (Exception ex)
            {
                //WriteLog.WriteLogs(ex.Message);
            }
        }
    }
}
