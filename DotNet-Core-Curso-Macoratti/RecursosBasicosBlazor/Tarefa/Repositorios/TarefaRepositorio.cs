using System;
using System.Collections.Generic;
using Tarefa.Modelos;

namespace Tarefa.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        public IEnumerable<TarefaModelo> ObterTodas()
        {
            return new List<TarefaModelo> {
                new TarefaModelo
                {
                    ID = Guid.NewGuid(),
                    Concluido = false,
                    DataCriacao = DateTime.Now,
                    Descricao = "Descrição 1"
                },
                new TarefaModelo
                {
                    ID = Guid.NewGuid(),
                    Concluido = false,
                    DataCriacao = DateTime.Now,
                    Descricao = "Descrição 2"
                }
            };
        }
    }
}
