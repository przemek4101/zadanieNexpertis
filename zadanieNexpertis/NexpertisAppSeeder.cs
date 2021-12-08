using System.Linq;
using zadanieNexpertis.Entities;
using Microsoft.AspNetCore.Identity;

namespace zadanieNexpertis
{
    public class NexpertisAppSeeder
    {
        private readonly NexpertisAppDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public NexpertisAppSeeder(NexpertisAppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var user = CreateTestUser();
                    _dbContext.Users.AddRange(user);
                    _dbContext.SaveChanges();
                }
            }
        }
        private User CreateTestUser()
        {
            var testUser = new User()
            {
                Name = "test",
            };
            var hashedPassword = _passwordHasher.HashPassword(testUser, "test");
            testUser.PasswordHash = hashedPassword;
            return testUser;
        }
    }
}
