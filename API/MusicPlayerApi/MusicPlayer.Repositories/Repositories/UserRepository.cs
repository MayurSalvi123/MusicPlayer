using MusicPlayer.Repositories.Interfaces;
using MusicPlayerApi.Core.Entities;
using MusicPlayerApi.DbContexts.MusicPlayerDbContexts;

namespace MusicPlayer.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicPlayerDbContext _dbContext;

        private bool disposed = false;

        public UserRepository(MusicPlayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            var createdUser = await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return createdUser.Entity;
        }

        public async Task DeleteUser(Guid Id)
        {
            var user = await _dbContext.Users.FindAsync(Id).ConfigureAwait(false);
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("User Does Not Exist");
            }
        }

        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users;
        }

        public User UpdateUser(User user)
        {
            var updatedUser = _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return updatedUser.Entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id).ConfigureAwait(false);
        }
    }
}
