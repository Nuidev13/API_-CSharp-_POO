using Biblioteca.Dominio;

Console.WriteLine("=== Ex 1 ===");
var marina = new Leitor("Marina", new DateTime(2011, 3, 10)); 
var sharknado = new DVD("Sharknado", "sharkão", ClassificacaoEtaria.DezesseisAnos);

try
{
    marina.RealizarEmprestimo(sharknado);
    Console.WriteLine("ERRO: não deveria ter permitido.");
}
catch (ExcecaoDominio ex)
{
    Console.WriteLine($"{ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== Ex2 ===");
var caio = new Leitor("Caio", new DateTime(2000, 5, 20));

var hamlet = new Livro("Hamlet", "William Shakespeare");
var reiLear = new Livro("Rei Lear", "William Shakespeare");
var deathNote = new Revista("Death Note", "Tsugumi Ohba");
var amnesia = new Revista("Amnésia", "Autor esqueceu");

var emprestimoHamlet = caio.RealizarEmprestimo(hamlet);
caio.RealizarEmprestimo(reiLear);
caio.RealizarEmprestimo(deathNote);

try
{
    caio.RealizarEmprestimo(amnesia);
    Console.WriteLine("ERRO: não deveria ter permitido.");
}
catch (ExcecaoDominio ex)
{
    Console.WriteLine($"{ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== Ex 3 ===");
caio.RegistrarDevolucao(emprestimoHamlet);
caio.RealizarEmprestimo(amnesia);
Console.WriteLine($"Empréstimo permitido: '{amnesia.Titulo}' para {caio.Nome}.");

Console.WriteLine();
Console.WriteLine("=== Ex 4 ===");
try
{
    reiLear.MarcarComoEmprestado();
    Console.WriteLine("ERRO: não deveria ter permitido.");
}
catch (ExcecaoDominio ex)
{
    Console.WriteLine($"{ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== Ex 5 ===");
var elias = new Leitor("Sr. Elias", new DateTime(1960, 1, 1));
var revistaFinal = new Revista("É o fim", "Autor END...");
var emprestimoElias = elias.RealizarEmprestimo(revistaFinal);

// Observação: como PrazoLimite depende de DateTime.Today no momento da criação,
// não dá pra "voltar no tempo" num console simples pra simular um atraso real
// sem mudar a modelagem (isso pediria injetar um "relógio" no domínio).
// O que este cenário prova é a parte que realmente importa pro bug relatado:
// depois de devolvido, MultaAtual passa a ler o valor TRAVADO em MultaFinal,
// e não recalcula mais nada com base em "hoje" — não importa quando alguém perguntar.
elias.RegistrarDevolucao(emprestimoElias);
decimal multaNaDevolucao = emprestimoElias.MultaAtual;
Console.WriteLine($"Multa registrada no momento da devolução: R$ {multaNaDevolucao}");

// "Duas semanas depois", alguém pergunta de novo:
decimal multaDepois = emprestimoElias.MultaAtual;
Console.WriteLine($"Multa consultada depois: R$ {multaDepois}");
Console.WriteLine(multaNaDevolucao == multaDepois
    ? "OK: o valor continua o mesmo, mesmo com o tempo passando."
    : "BUG: o valor mudou depois da devolução!");
