using System;

namespace Classes.Shared.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        private DateTime _dataDoCadastro;
        public DateTime DataDoCadastro {
            set { _dataDoCadastro = value; }
        }

        public string PegarDataDoCadastroFormatada()
        {
            return _dataDoCadastro.ToString("dd/MM/yyyy");
        }

        public static Produto PegarProdutoMock()
        {
            return new Produto
            {
                Nome = "Produto mock",
                DataDoCadastro = DateTime.Now
            };
        }
    }
}
