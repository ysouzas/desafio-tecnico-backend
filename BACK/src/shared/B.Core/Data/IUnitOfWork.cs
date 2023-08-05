namespace B.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}

