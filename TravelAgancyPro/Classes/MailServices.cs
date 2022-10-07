using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgancyPro.Classes
{

    public static class SendMailViaProvider
    {
        public static void SendViaGmail(string ReceiverEmail, string SenderEmail, string SenderEmailPassword, string MailBody, string AttachmentFilePath, string MailSubject)
        {

            IMail mail = new Mail();
            mail.SendMail(ReceiverEmail, SenderEmail, SenderEmailPassword, MailBody, AttachmentFilePath, MailSubject, "smtp.gmail.com", 587);
        }

    }


    class Mail : IMail
    {

        public void SendMail(string ReceiverEmail, string SenderEmail, string SenderEmailPassword, string MailBody, string AttachmentFilePath, string MailSubject, string Host, int Port)
        {
            string to = ReceiverEmail; //To address    
            string from = SenderEmail; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = MailBody;
            message.Subject = MailSubject;
            message.Body = mailbody;
            if (AttachmentFilePath != null)
            {
                message.Attachments.Add(new Attachment(AttachmentFilePath));

            }
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(Host, Port); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(SenderEmail, SenderEmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

    }


    interface IMail
    {
        void SendMail(string ReceiverEmail, string SenderEmail, string SenderEmailPassword, string MailBody, string AttachmentFilePath, string MailSubject, string Host, int Port);
    }


}
