namespace B.API.DTOs;


public readonly record struct UpdateCardDTO(Guid id, string Titulo, string Conteudo, string Lista);

