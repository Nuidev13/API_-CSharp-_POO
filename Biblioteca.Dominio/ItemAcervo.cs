using System.Data.Common;
using System.Dynamic;

namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{


    private static int _proximoId = 1;

    public int Id {get;}

    public ItemAcervo(string titulo, string autor)
    {
        if(string.IsNullOrWhiteSpace(titulo))
        {
            throw new InvalidOperationException("O título não pode ser vazio.");
        }
        if(string.IsNullOrWhiteSpace(autor))
        {
            throw new InvalidOperationException("O autor não pode ser vazio.");
        }
        Titulo = titulo;
        Autor = autor;
        Id = _proximoId++;
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

 public void MarcarComoDevolvido()
 {
    if(Disponibilidade)
    {
        throw new ExcecaoDominio("Não está emprestado");
    }
   Disponibilidade = true;  
 }

 public void MarcarComoEmprestado()
 {    
    if(!Disponibilidade)
    {
        throw new ExcecaoDominio("Não está emprestado");
    }
    Disponibilidade = false;
 }

}