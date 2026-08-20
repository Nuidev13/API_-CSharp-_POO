namespace Biblioteca.Dominio;

public class Leitor
{

    private readonly List<Emprestimo> _emprestimosAtivos = new List<Emprestimo>();

     public IReadOnlyCollection<Emprestimo> EmprestimosAtivos => _emprestimosAtivos.AsReadOnly();

      
    public string Nome { get; }
    public DateTime DataNascimento { get; }

    public Leitor(string nome, DateTime dataNascimento)
    {
         if(string.IsNullOrWhiteSpace(nome))
        {
            throw new InvalidOperationException("O nome não pode ser vazio.");
        }

        if (dataNascimento > DateTime.Today)
        {
            throw new InvalidOperationException("A data de nascimento não pode ser no futuro.");
        }
        
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public int Idade
    {
        get
        {
            int idade = DateTime.Today.Year - DataNascimento.Year;
        if (DateTime.Today < DataNascimento.AddYears(idade))
        {
            idade--;
        }
        return idade;
        }  
    }

    public const int LimiteDeEmprestimos = 3;

    public Emprestimo RealizarEmprestimo(ItemAcervo item)
{
   if (_emprestimosAtivos.Count >= LimiteDeEmprestimos)
   {
       throw new ExcecaoDominio("O leitor atingiu o limite de empréstimos ativos.");
   }

   if (item is DVD dvd && Idade < (int)dvd.Classificacao)
   {
       throw new ExcecaoDominio($"{Nome} tem {Idade} anos e este DVD é classificado para {(int)dvd.Classificacao} anos ou mais.");
   }

   var emprestimo = new Emprestimo(item, this);
   _emprestimosAtivos.Add(emprestimo);
   return emprestimo;
}

    public void RegistrarDevolucao(Emprestimo emprestimo)
    {
        if (!_emprestimosAtivos.Contains(emprestimo))
        {
            throw new ExcecaoDominio("Este empréstimo não pertence a este leitor ou já foi devolvido.");
        }

        emprestimo.RegistrarDevolucao();
        _emprestimosAtivos.Remove(emprestimo);
    }
}