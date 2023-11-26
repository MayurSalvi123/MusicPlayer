using System.Web.Mvc;
using AutoMapper;
using MusicPlayer.Managers.Interfaces;
using MusicPlayerApi.Core.Dtos.User;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayerApi.Controllers.UserController
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            var userObject = _mapper.Map<User>(userDto);
            var createdUser = await _userManager.AddUser(userObject).ConfigureAwait(false);
            return _mapper.Map<UserDto>(createdUser);
        }
        public async Task<List<UserDto>>GetAllUsers(FetchUserDto fetchUserDto)
        {
            var users = await _userManager.GetAll().ConfigureAwait(false);
            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task RemoveUser(RemoveUserDto userDto)
        {
            await _userManager.DeleteUser(userDto.UserId).ConfigureAwait(false);
        }
        public async Task<UserDto> UpdateUser(UpdateUserDto userDto)
        {
            var userObject = _mapper.Map<User>(userDto);
            var updatedUser = await _userManager.UpdateUser(userObject).ConfigureAwait(false);
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
