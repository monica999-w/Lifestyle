using Lifestyle.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Models
{
    public class EmailSender
    {

        public void SendEmailToUser(List<UserProfile> users, string subject, string body)
        {

            string senderEmail = "monica.iliescu99@gmail.com";
            string senderPassword = "ztfp vxdd yyfg erbz";

            foreach (var user in users)
            {
                bool isEmailSent = SendEmail(user.Email, subject, body, senderEmail, senderPassword);

                if (isEmailSent)
                {
                    Console.WriteLine($"E-mail sent successfully to: {user.Email}");
                }
                else
                {
                    Console.WriteLine($"Failed to send e-mail to {user.Email}");
                }
            }
        }

        private bool SendEmail(string recipientEmail, string subject, string body, string senderEmail, string senderPassword)
        {

               
                using MailMessage message = new MailMessage();
                message.From = new MailAddress(senderEmail);
                message.To.Add(new MailAddress(recipientEmail));
                message.Subject = subject;
                message.Body = body;

                using SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                   Port = 587,
                   Credentials = new NetworkCredential(senderEmail, senderPassword),
                   EnableSsl = true,
                };

                try
                {
                smtpClient.Send(message);
                return true; 
                }
                catch (Exception ex)
                {
                Console.WriteLine($"Failed to send e-mail: {ex.Message}");
                return false; 
                }

        }
    }
}
