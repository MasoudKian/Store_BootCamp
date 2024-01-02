using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Store_BootCamp.Application.Senders
{
    public class SendEmail
    { 
        public static void Send(string to,string subject,string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("masoudkiannezhad@gmail.com", "فعال سازی حساب کاربری");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("masoudkiannezhad@gmail.com", "dsqq hntb gyyc xcvy");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}