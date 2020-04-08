using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePDFSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var documento = new PdfDocument())
            {
                documento.Info.Title = "Olá mundo";
                var pagina = documento.AddPage();
                var grafico = XGraphics.FromPdfPage(pagina);

                var formatadorDeTexto = new XTextFormatter(grafico);
                var fonte = new XFont("Arial", 12, XFontStyle.Regular);
                var corDaFonte = XBrushes.Black;
                var posicaoTexto = new XRect(0, pagina.Height / 7, pagina.Width, pagina.Height);

                // Coloca o texto no meio do eixo horizontal
                formatadorDeTexto.Alignment = XParagraphAlignment.Center;

                // Coloca o texto na página
                formatadorDeTexto.DrawString("Hello World", fonte, corDaFonte, posicaoTexto, XStringFormats.TopLeft);


                //Desenha linhas para fazer uma margem
                grafico.DrawLine(XPens.Black, 20, 20, pagina.Width - 20, 20);//top
                grafico.DrawLine(XPens.Black, 20, pagina.Height - 20, pagina.Width - 20, pagina.Height - 20);//bottom
                grafico.DrawLine(XPens.Black, 20, 20, 20, pagina.Height - 20);//left
                grafico.DrawLine(XPens.Black, pagina.Width - 20, 20, pagina.Width - 20, pagina.Height - 20);//right

                // Usa um retangulo para fazer uma margem
                grafico.DrawRectangle(XPens.BlueViolet, 30, 30, pagina.Width - 60, pagina.Height - 60);
                // Usa um retangulo com cor de fundo(opcional) para fazer uma margem
                grafico.DrawRectangle(XPens.BlueViolet, XBrushes.CadetBlue, pagina.Width / 2, pagina.Height / 2, 50, 50);

                Console.WriteLine("posição dos items: " + pagina.Width + " he " + pagina.Height);

                //Coloca uma imagem no pdf
                grafico.DrawImage(XImage.FromFile(@"C:\Users\Anderson\Pictures\215569.jpg"), pagina.Width / 2,  pagina.Height / 1.7, 200, 70);


                //Salva o arquivo e abre no visualizador padrão
                const string nomeDoArquivo = "helloworld.pdf";
                documento.Save(nomeDoArquivo);
                Process.Start(nomeDoArquivo);
            }
        }
    }
}
