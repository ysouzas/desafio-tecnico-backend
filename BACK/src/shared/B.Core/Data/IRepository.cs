namespace B.Core.Data;

public interface IRepository<T> : IDisposable
{
    IUnitOfWork UnitOfWork { get; }

    Task Add(T player);

    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(Guid id);

    Task Delete(T player);

    Task<T> Update(T player);
}