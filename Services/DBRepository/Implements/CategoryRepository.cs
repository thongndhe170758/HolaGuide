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
        public CategoryRepository(HolaGuide_TestContext context) : base(context) { }

        public List<Category> Gets(Expression<Func<Category, bool>> expression)
        {
            return DbContext.Categories.Where(expression).ToList();
        }
    }
}
