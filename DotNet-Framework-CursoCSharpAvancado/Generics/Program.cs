using Generics.Models;
using Generics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var carro = new Carro { Marca = "FIAT", Modelo = "UNO" };
            var carro2 = new Carro { Marca = "FORD", Modelo = "Fiesta" };
            var usuario = new Usuario { Nome = "Maria", Email = "maria@email.com" };

            Repositorio<Carro>.SalvarTodos(carro, carro2);
            Repositorio<Usuario>.Salvar(usuario);

            Repositorio<Carro>.PegarTodos().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            Repositorio<Usuario>.PegarTodos().ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
