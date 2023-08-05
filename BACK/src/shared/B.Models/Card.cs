
namespace B.Models;

public class Card : Entity
{

    public Card()
    {
    }

    public Card(string titulo, string conteudo, string lista)
    {
        Titulo = titulo;
        Conteudo = conteudo;
        Lista = lista;
    }

    public Card(Guid id, string titulo, string conteudo, string lista)
    {
        Id = id;
        Titulo = titulo;
        Conteudo = conteudo;
        Lista = lista;
    }

    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public string Lista { get; set; }
}

