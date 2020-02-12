using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Models
{
    public class Filtro
    {
        public bool Antigo { get; set; }
        public bool Negados { get; set; }
        public bool Aceitos { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Nome { get; set; }
    }
}