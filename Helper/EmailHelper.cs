using System.Net.Mail;
using System.Net;
using System.IO;

namespace ASPWebApp.Helpers
{
    public static class EmailHelper
    {
        public static void SendOtpEmail(string email, string otp)
        {
            var from = "kkpp42877@gmail.com";
            var password = "rvqfsibrlarlhfsx";

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(),
                "Views",
                "Shared",
                "Email",
                "OtpTemplate.html"
            );

            var body = File.ReadAllText(templatePath);
            body = body.Replace("{{OTP}}", otp);

            var message = new MailMessage();
            message.From = new MailAddress(from);
            message.To.Add(email);
            message.Subject = "Your OTP Code";
            message.Body = body;
            message.IsBodyHtml = true; // IMPORTANT

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
}
