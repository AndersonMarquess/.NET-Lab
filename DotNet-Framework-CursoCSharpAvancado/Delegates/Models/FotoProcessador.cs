using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Models
{
    class FotoProcessador
    {
        public delegate void TratadorDeFiltroDeFoto(Foto foto);

        public static TratadorDeFiltroDeFoto filtros;

        public static void Processar(Foto foto)
        {
            filtros(foto);
        }
    }
}
