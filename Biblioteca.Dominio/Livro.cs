namespace Biblioteca.Dominio;

public class Livro(string titulo, string autor) : ItemAcervo(titulo, autor)
{
   public override int PrazoDevolucao => 14;
   public override decimal MultaDeAtraso => 1.0m;
}