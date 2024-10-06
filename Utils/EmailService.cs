using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class EmailService
    {
        public void EnviarCorreo(string destinatario, string username, string voucher, string articulo )
        {
            try
            {
                string htmlBody = System.IO.File.ReadAllText("Mailin/Confirmacion.html");

                htmlBody = htmlBody.Replace("{{voucher}}", voucher);
                htmlBody = htmlBody.Replace("{{nombre}}", username);
                htmlBody = htmlBody.Replace("{{articulo}}", articulo);


                // Configuración del correo
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tucorreo@tudominio.com");
                mail.To.Add(destinatario);
                mail.Subject = "¡Confirmación de Participación en el Sorteo!";
                mail.Body = htmlBody;
                mail.IsBodyHtml = true; // Para permitir HTML en el cuerpo del correo si lo necesitas

                // Configuración del servidor SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net");
                smtpClient.Port = 587; // Puede variar según el servicio SMTP
                smtpClient.Credentials = new NetworkCredential("tucorreo@tudominio.com", "tucontraseña");
                smtpClient.EnableSsl = true; // Activar SSL para conexiones seguras

                // Enviar el correo
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error
                Console.WriteLine("Error enviando correo: " + ex.Message);
            }
        }
    }
}
