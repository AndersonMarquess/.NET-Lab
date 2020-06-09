using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Models
{
    class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public override string ToString()
        {
            return $"Marca: {Marca} - Modelo: {Modelo}";
        }
    }
}
