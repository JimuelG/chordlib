using Core.Entities;

namespace Core.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
}