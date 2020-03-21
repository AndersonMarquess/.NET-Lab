//Todo código javascript precisa estar em escopo de window e ser importado no index.html
window.MostrarAlerta = function alertaNavegador(mensagem) {
    alert(mensagem);
}

async function RecuperarTotalDeTarefas() {
    //Nome do projeto, nome do método (que foi anotado com JSInvokable)
    const resultado = await DotNet.invokeMethodAsync("Tarefa", "ObterTotalDeTarefas");
    window.MostrarAlerta(resultado);
}

async function RecuperarTotalConcluido(dotnet) {
    //Como o "contexto" será passado por argumento, apenas o nome do método é necessário
    const resultado = await dotnet.invokeMethodAsync("ObterTotalDeTarefasConcluidas");
    window.MostrarAlerta(resultado);
}