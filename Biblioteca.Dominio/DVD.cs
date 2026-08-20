namespace Biblioteca.Dominio;

public class DVD(string titulo, string autor, ClassificacaoEtaria classificacao) : ItemAcervo(titulo, autor)
{
   public override int PrazoDevolucao => 3;
   public override decimal MultaDeAtraso => 3.0m;

   public ClassificacaoEtaria Classificacao { get; } = classificacao;
}
