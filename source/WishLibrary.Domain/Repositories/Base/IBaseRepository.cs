namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task<ICollection<T>?> ObterTudo<T>() where T : class;
        Task<T?> ObterporId<T>(int id) where T : class;
        Task<T> Adicionar<T>(T entity) where T : class;
        Task<T> Atualizar<T>(T entity) where T : class;
        Task<T> Apagar<T>(T entity) where T : class;
    }
}
