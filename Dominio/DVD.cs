using System.Dynamic;

namespace Biblioteca.Dominio;

public class DVD(string titulo, string autor) : ItemAcervo(titulo, autor)
{
   public override int PrazoDevolucao => 3;
   public override decimal MultaDeAtraso => 3.0m;
}