using MusicPlayerApi.Core.Entities;

namespace MusicPlayer.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<User> AddUser(User user);
        Task DeleteUser(Guid id);
        Task<List<User>> GetAll();
        Task<User> UpdateUser(User user);
    }
}
