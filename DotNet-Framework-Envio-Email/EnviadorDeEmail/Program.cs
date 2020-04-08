using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnviadorDeEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.EnableSsl = true;
            // é necessário permitir o acesso de apps menos seguros no link: https://myaccount.google.com/lesssecureapps
            cliente.Credentials = new NetworkCredential("testesmtp174@gmail.com", "senha");

            try
            {
                cliente.Send(PegarEmail());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static MailMessage PegarEmail()
        {
            var email = new MailMessage();
            email.Sender = new MailAddress("testesmtp174@gmail.com", "Enviador");
            email.From = new MailAddress("testesmtp174@gmail.com", "Enviador");
            email.To.Add(new MailAddress("logoy45043@fft-mail.com", "Recebedor"));
            email.Subject = "Contato teste";
            email.Body = PegarCorpoDoEmail();
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;

            return email;
        }

        private static string PegarCorpoDoEmail()
        {
            return @"
                    <table>
                        <thead>
                            <td>Mensagem</td>
                        </thead>
                        <tbody>
                            <td><b>Hello</b> World</td>
                        </tbody>
                    </table>
                ";
        }
    }
}
