using MusicPlayerApi.Core.Entities;

namespace MusicPlayer.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<User> AddUser(User user);
        Task DeleteUser(Guid Id);
        Task<User> GetUserById(Guid id);
        IQueryable<User> GetUsers();
        User UpdateUser(User user);
    }
}
