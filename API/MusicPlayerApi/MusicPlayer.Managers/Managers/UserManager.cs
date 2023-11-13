using Microsoft.EntityFrameworkCore;
using MusicPlayer.Managers.Interfaces;
using MusicPlayer.Repositories.Interfaces;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayer.Managers.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User> AddUser(User user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id).ConfigureAwait(false);
            if (existingUser != null)
            {
                throw new Exception($"User Alreadyt Exist with Id {user.Id}");
            }
            else
            {
                return await _userRepository.AddUser(user);
            }
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id).ConfigureAwait(false);
        }
        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetUsers().ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id).ConfigureAwait(false);
            if (existingUser == null)
            {
                throw new Exception($"User Does Not Exist with Id {user.Id}");
            }
            else
            {
                return await Task.FromResult(_userRepository.UpdateUser(user)).ConfigureAwait(false);
            }
        }
    }
}
