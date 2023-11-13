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

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteUser(Guid Id)
        {
            var user = await _dbContext.Users.FindAsync(Id).ConfigureAwait(false);
            if(user != null)
            {
                _dbContext.Users.Remove(user);
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

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
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
    }
}
