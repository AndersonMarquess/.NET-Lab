using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Services
{
    class Repositorio<T>
    {
        private static readonly List<T> _dados = new List<T>();

        public static void SalvarTodos(params T[] itens)
        {
            foreach (var item in itens)
            {
                Salvar(item);
            }
        }

        public static void Salvar(T item)
        {
            _dados.Add(item);
        }

        public static List<T> PegarTodos()
        {
            return _dados;
        }
    }
}
