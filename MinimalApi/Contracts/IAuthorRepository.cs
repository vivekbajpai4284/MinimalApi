using MinimalApi.Model;

namespace MinimalApi.Contracts
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAuthorsAsync();
    }
}
