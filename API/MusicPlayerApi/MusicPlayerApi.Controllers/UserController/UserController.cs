using System.Web.Mvc;
using MusicPlayer.Managers.Interfaces;
using MusicPlayerApi.Core.Dtos;

namespace MusicPlayerApi.Controllers.UserController
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            return null;
        }
        public async Task<List<UserDto>>GetAllUsers(FetchUserDto fetchUserDto)
        {
            return null;
        }
        public async Task<UserDto> RemoveUser(UpdateUserDto userDto)
        {
            return null;
        }
        public async Task<UserDto> UpdateUser(UpdateUserDto userDto)
        {
            return null;
        }
    }
}
