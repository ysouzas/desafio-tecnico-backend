namespace B.API.DTOs;

public readonly record struct CardDTO(Guid Id, string Titulo, string Conteudo, string Lista);
