using MusicPlayerApi.Core.Entities;

namespace MusicPlayer.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task AddUser(User user);
        Task DeleteUser(Guid Id);
        IQueryable<User> GetUsers();
        void UpdateUser(User user);
    }
}
