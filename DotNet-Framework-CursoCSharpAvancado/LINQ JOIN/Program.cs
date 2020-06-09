using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_JOIN
{
    class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    class Obra
    {
        public int Id { get; set; }
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public TipoObra Tipo { get; set; }
    }

    enum TipoObra : int
    {
        Livro = 1,
        Filme = 2,
        Jogo = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var autor1 = new Autor { Id = 1, Nome = "José" };
            var autor2 = new Autor { Id = 2, Nome = "Maria" };
            var autor3 = new Autor { Id = 3, Nome = "Júlia" };
            var autores = new List<Autor> { autor1, autor2, autor3 };

            var obra1 = new Obra { Id = 1, AutorId = 1, Nome = "Obra 1", Tipo = TipoObra.Filme };
            var obra2 = new Obra { Id = 2, AutorId = 2, Nome = "Obra 2", Tipo = TipoObra.Jogo };
            var obra3 = new Obra { Id = 2, AutorId = 2, Nome = "Obra 3", Tipo = TipoObra.Jogo };
            var obra4 = new Obra { Id = 4, AutorId = 3, Nome = "Obra 4", Tipo = TipoObra.Livro };
            var obras = new List<Obra> { obra1, obra2, obra3, obra4 };

            //Join das duas fontes
            var autoresComObras = from obra in obras
                                  join autor in autores
                                  on obra.AutorId equals autor.Id
                                  select new { obra.Tipo, Titulo = obra.Nome, AutorObra = autor.Nome };

            foreach (var item in autoresComObras)
            {
                Console.WriteLine($"{item.Tipo} - {item.Titulo} - {item.AutorObra}");
            }

            Console.ReadLine();
        }
    }
}
