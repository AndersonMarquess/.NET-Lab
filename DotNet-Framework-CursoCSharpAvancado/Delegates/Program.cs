using Delegates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {

        static void Main(string[] args)
        {
            // DelegateSimples();
            var foto = new Foto { Nome = "imgagem.gif", TamanhoX = 854, TamanhoY = 480 };
            
            var filtros = new FotoFiltro();
            
            // Será executado em sequencia.
            FotoProcessador.filtros = filtros.Colorir;
            FotoProcessador.filtros += filtros.RemoverFundo;
            FotoProcessador.filtros += filtros.GerarMinuatura;
            FotoProcessador.Processar(foto);

            Console.ReadLine();
        }

        delegate float Calcular(float val1, float val2);

        private static void DelegateSimples()
        {
            Calcular calcSoma = new Calcular(Somar);
            Console.WriteLine(calcSoma(5, 10) == 15);

            Calcular calcSubtrair = new Calcular(Subtrair);
            Console.WriteLine(calcSubtrair(5, 10) == -5);
        }

        static float Somar(float val1, float val2)
        {
            return val1 + val2;
        }

        static float Subtrair(float val1, float val2)
        {
            return val1 - val2;
        }
    }
}
