namespace Biblioteca.Dominio;

public class Leitor
{
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
}