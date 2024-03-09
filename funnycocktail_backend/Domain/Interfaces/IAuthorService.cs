using Domain.DTOS;

namespace Domain.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorDTO> GetAuthorByIdAsync(int Id);
        public Task<string> CreateUsernameAsync(string username);
    }
}
