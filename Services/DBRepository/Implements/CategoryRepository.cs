using Infrastructure.SQLServer;
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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(HolaGuide_TestContext holaGuide_TestContext) : base(holaGuide_TestContext) { }

        public List<Category> Gets(Expression<Func<Category, bool>> predicate)
        {
            return DbContext.Categories.Where(predicate).ToList();
        }

        public Category? Get(Expression<Func<Category, bool>> predicate)
        {
            return DbContext.Categories.FirstOrDefault(predicate);
        }
    }
}
