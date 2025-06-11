using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
namespace BLL.Classes
{
    public class SendEmail
    {
        public void SendToEmail(string toEmail, string subject, Customers c)
        {
            string body = "hello " + c.Name + "Message from the Photo Your order is ready";
            var fromAddress = new MailAddress("racheli9127@gmail.com", "Photo"); // כתובת המייל שלך
            var toAddress = new MailAddress(toEmail); // כתובת המייל של הלקוח
            const string fromPassword = "arxcjjcwoagvvpbo"; // הסיסמא שלך
                                                            // const string smtpHost = "smtp.gmail.com"; // השרת SMTP שלך
                                                            //const int smtpPort = 587; // פורט (בדרך כלל 587 או 465)

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                //Port = smtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {

                //ViewBag.Message = "שגיאה בשליחת המייל: " + ex.Message;
            }
        }
    }
}

