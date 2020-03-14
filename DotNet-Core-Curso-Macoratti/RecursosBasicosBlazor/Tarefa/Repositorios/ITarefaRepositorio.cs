using System.Collections.Generic;
using Tarefa.Modelos;

namespace Tarefa.Repositorios
{
    interface ITarefaRepositorio
    {
        IEnumerable<TarefaModelo> ObterTodas();
    }
}
