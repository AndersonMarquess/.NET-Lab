using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Models
{
    class FotoFiltro
    {
        public void Colorir(Foto foto)
        {
            Console.WriteLine("Colorindo foto ", foto.Nome);
        }

        public void GerarMinuatura(Foto foto)
        {
            Console.WriteLine("Gerando miniatura da foto ", foto.Nome);
        }


        public void PretoEBranco(Foto foto)
        {
            Console.WriteLine("Aplicando filtro de preto e branco na foto ", foto.Nome);
        }


        public void Redimensionar(Foto foto)
        {
            Console.WriteLine("Redimensionando foto ", foto.Nome);
        }


        public void RemoverFundo(Foto foto)
        {
            Console.WriteLine("Removendo fundo da foto ", foto.Nome);
        }
    }
}
