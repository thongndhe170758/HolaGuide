using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Implements
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(HolaGuide_TestContext dbContext) : base(dbContext) { }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await DbContext.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<User>> Gets(Expression<Func<User, bool>> predicate)
        {
            return await DbContext.Users.Where(predicate).ToListAsync();
        }

        public string GenerateUserCode()
        {
            bool isExist = false;
            string code = string.Empty;
            do
            {
                var codenumber = new Random().Next(100000, 999999);
                code = $"HG{codenumber}";
                isExist = DbContext.Users.Any(u => u.Code.Equals(code));
            }
            while(!isExist);
            return code; 
        }
    }
}
