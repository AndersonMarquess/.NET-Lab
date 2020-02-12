using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Models
{
    public class Context
    {
        private static List<Cliente> _clientes { get; set; }

        public static void RemoverComCodigo(int codigo)
        {
            _clientes.RemoveAll(c => c.Codigo == codigo);
        }

        public static List<Cliente> RecuperarClientesMock()
        {
            if (_clientes == null || !_clientes.Any())
            {
                PopularClientes();
            }

            return _clientes;
        }

        private static void PopularClientes()
        {
            _clientes = new List<Cliente>
            {
                new Cliente(1, "Cliente 1", "1234-5678"),
                new Cliente(2, "Cliente 2", "9012-3456"),
                new Cliente(3, "Cliente 3", "9876-5432"),
            };
        }

        public static void Atualizar(Cliente cliente)
        {
            RemoverComCodigo(cliente.Codigo);
            _clientes.Add(cliente);
        }

        public static void Adicionar(Cliente cliente) {
            _clientes.Add(cliente);
        }
    }
}