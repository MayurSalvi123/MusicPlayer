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

        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users;
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
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
