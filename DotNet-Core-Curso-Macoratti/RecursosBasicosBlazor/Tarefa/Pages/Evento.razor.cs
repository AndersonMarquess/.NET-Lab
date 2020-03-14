using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Tarefa.Pages
{
    public class EventoBase : ComponentBase
    {
        protected string _cor { get; set; } = "lightgreen";

        protected void TeclaPressionada(KeyboardEventArgs args)
        {
            Console.WriteLine($"Tecla pressionada: {args.Key}");
            if (args.Key == "A" || args.Key == "a")
            {
                _cor = "blue";
            }
        }
    }
}
