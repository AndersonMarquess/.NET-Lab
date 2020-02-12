using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Cliente()
        {

        }

        public Cliente(int codigo, string nome, string telefone)
        {
            Codigo = codigo;
            Nome = nome;
            Telefone = telefone;
        }
    }
}