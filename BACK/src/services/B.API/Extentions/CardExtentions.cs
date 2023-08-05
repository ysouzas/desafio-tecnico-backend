using B.API.DTOs;
using B.Models;

namespace B.API.Extentions;

public static class CardExtentions
{
    public static CardDTO ToCardDTO(this Card me)
    {
        return new CardDTO
        {
            Id = me.Id,
            Titulo = me.Titulo,
            Conteudo = me.Conteudo,
            Lista = me.Lista,
        };
    }


    public static CardDTO[] ToCardDTO(this ICollection<Card> me)
    {
        return me.Select(p => p.ToCardDTO()).ToArray();
    }
}

