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
            cliente.Credentials = new NetworkCredential("testesmtp174@gmail.com", "LpPL6EfvGRG5gFh");

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
            email.To.Add(new MailAddress("testesmtp174@gmail.com", "Recebedor"));
            email.Subject = "Contato teste "+DateTime.Now.Ticks;
            email.Body = PegarCorpoDoEmail();
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;

            return email;
        }

        private static string PegarCorpoDoEmail()
        {
            return @"<table>
                        <thead>
                            <tr>
                                <th><h2 style='text-align: initial;'>Mensagem</h2></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><b>Hello</b> World</td>
                            </tr>
                            <tr>
                                <td style='max-width: 700px'>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</td>
                            </tr>
                            <tr><td><img src='https://www.bauducco.com.br/wp-content/uploads/2017/09/default-placeholder-1-2.png' style='width: 450px;'></img></td></tr>
                            <tr>
                                <td style='text-align: end;'>Fim da mensagem</td>
                            </tr>
                        </tbody>
                    </table>
                ";
        }
    }
}
