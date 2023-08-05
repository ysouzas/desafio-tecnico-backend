namespace B.Core.Data;

public interface IRepository<T> : IDisposable
{
    IUnitOfWork UnitOfWork { get; }

    Task<T> Add(T card);

    Task<ICollection<T>> GetAll();

    Task<T> GetById(Guid id);

    Task Delete(T card);

    T Update(T card);
}