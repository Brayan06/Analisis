using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DACorreo
    {
        MailMessage msg = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        public string EnvioCorreo(string emisor, string pass, string receptor, string ruta, string mssg, string asunto) {

            try
            {
                msg.To.Add(receptor);
                msg.Subject = asunto;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = mssg;
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.Priority = MailPriority.High;
                Attachment archivo = new Attachment(ruta);
                msg.Attachments.Add(archivo);
                msg.From = new MailAddress(emisor);


                smtp.Credentials = new NetworkCredential(emisor, pass);
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(msg);
                return "Mensaje enviado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al enviar el correo. "+ex.Message;
            }
            
        }
    }
}
