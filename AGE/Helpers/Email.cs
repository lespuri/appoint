using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Helpers
{
    public class Email
    {
        private SmtpClient client;

        private MailMessage mail;
        public Email()
        {
            client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("99appointplus@gmail.com", "82le!86sp09ur4I");
            mail = new MailMessage();
        }

        public void enviar(string prEmailPara, string prTitulo, string prMensagem)
        {
            mail.Sender = new System.Net.Mail.MailAddress("99appointplus@gmail.com", "Appoint Plus");
            mail.From = new MailAddress("99appointplus@gmail.com", "Appoint Plus");
            mail.To.Add(new MailAddress("99appointplus@gmail.com", "Appoint Plus"));
            foreach (var item in prEmailPara.Split(';'))
            {
                mail.Bcc.Add(new MailAddress(item, ""));
            }
            
            mail.Subject = prTitulo;
            mail.Body = prMensagem;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }

        }
    }
}
