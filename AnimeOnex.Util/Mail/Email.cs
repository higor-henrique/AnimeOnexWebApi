using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace AnimeOnex.Util.Mail
{
    public class Email
    {
        public void Enviar()
        {

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("stromps2019@gmail.com");
            mail.To.Add("higheitor@gmail.com"); // para
            mail.Subject = "Teste"; // assunto
            mail.Body = "Testando mensagem de e-mail"; // mensagem
            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("stromps2019@gmail.com", "qwertyuiop123!#");

                // envia o e-mail
                smtp.Send(mail);
            }
            


        }
    }
}
