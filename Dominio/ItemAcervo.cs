
using System.Security.Cryptography.X509Certificates;

namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{
 
 protected ItemAcervo(string título, string autor)
    {

        if(string.IsNullOrEmpty(título))
        {
            throw new ExcecaoDominio("O título não pode ser vazio.");
        }
        Titulo = título;
        Autor = autor;
    }

 public string Titulo { get; set; }   = string.Empty;

 public string Autor { get; set; }    = string.Empty;

 public bool Disponibilidade { get; private set; } = true;

 public abstract int PrazoDevolucao { get;} 

 public abstract decimal MultaDeAtraso { get; }

 public decimal CalcularMulta(int diasAtraso) 
 {
  return diasAtraso >= 0 ? diasAtraso * MultaDeAtraso : 0;
 }
}