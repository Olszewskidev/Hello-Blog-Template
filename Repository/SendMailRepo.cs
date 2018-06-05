using System;
using System.Net;
using System.Net.Mail;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class SendMailRepo : ISendEmail
    {
        private string EmailName;
        private string EmailContact;
        private string EmailSub;
        private string EmailText;

        public string SendEmail(EmailData eData)
        {
            EmailName = eData.SenderName;
            EmailContact = eData.SenderMail;
            EmailSub = eData.SenderSubject;
            EmailText = eData.SenderText; 

            if (EmailName == null || EmailContact == null || EmailSub == null || EmailText == null)
                return "Wiadomość nie została wysłana, sprawdź czy uzupełniłeś wszystkie pola";
            else
            {
                var isSend = SMPT();
                return (isSend) ? "Wiadomość zostałą wysłana" : "Wiadomość nie została wysłana";
            }       
        }
        private bool SMPT()
        {
            try
            {
                MailMessage mail = new MailMessage();
                var SmtpServer = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("kontaktolszewskidev@gmail.com", "************")
                };

                mail.From = new MailAddress("kontaktolszewskidev@gmail.com");
                mail.To.Add("kontaktolszewskidev@gmail.com");
                mail.Subject = EmailSub;
                mail.Body = "<b> Sender Name : </b>" + EmailName + "<br/>" + "<b>Sender Email : </b>" + EmailContact + "<br/>" + "<b> Text : </b>" + EmailText;
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
     
        }
    }
}