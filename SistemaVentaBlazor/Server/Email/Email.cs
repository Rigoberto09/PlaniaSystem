using System.Net.Mail;
using System.Net;

namespace SistemaPlania.Server.Email
{
    public class Email
    {
        private readonly string _smtpServer = "smtp.gmail.com"; // servidior de GMAIL
        private readonly int _smtpPort = 587; // Puerto para TLS
        private readonly string _smtpUsername = "rpione8@gmail.com"; // Correop para de envios
        private readonly string _smtpPassword = "eerw ihxw feqy fssy"; // CONTRASELA DE MAQUINA

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                    smtpClient.EnableSsl = true; // Cambia a false si no usas SSL

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpUsername),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true 
                    };
                    mailMessage.To.Add(toEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
                return false;
            }
        }
    }
}
