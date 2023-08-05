﻿namespace B.Core.Data;

public interface IRepository<T> : IDisposable
{
    IUnitOfWork UnitOfWork { get; }

    Task Add(T card);

    Task<ICollection<T>> GetAll();

    Task<T> GetById(Guid id);

    Task Delete(T card);

    Task<T> Update(T card);
}