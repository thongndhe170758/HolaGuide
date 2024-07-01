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

        public User? Get(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Users.FirstOrDefault(predicate);
        }

        public List<User> Gets(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Users.Where(predicate).ToList();
        }

        public string Create(User user)
        {
            try
            {
                user.Code = GenerateUserCode();
                DbContext.Users.Add(user);
                var result = DbContext.SaveChanges();
                if (result != 0) return "Đăng kí thành công";
                return "Đăng kí thất bại";
            }
            catch(Exception ex)
            {
                return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
        }

        public string UpdateActivation(User updateUser)
        {
            try
            {
                var user = DbContext.Users.FirstOrDefault(u => u.Email == updateUser.Email);
                if (user == null) return $"Can not find user with email '{updateUser.Email}'";
                if (updateUser.IsActivate == user.IsActivate) return "Nothing to update!";
                user.IsActivate = updateUser.IsActivate;
                DbContext.Entry(user).State = EntityState.Modified;
                return DbContext.SaveChanges().ToString();
            }
            catch(Exception ex)
            {
                return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
        }

        private string GenerateUserCode()
        {
            bool isExist = false;
            string code = string.Empty;
            do
            {
                var codenumber = new Random().Next(100000, 999999);
                code = $"HG{codenumber}";
                isExist = !DbContext.Users.Any(u => u.Code.Equals(code));
            }
            while(!isExist);
            return code; 
        }
    }
}
