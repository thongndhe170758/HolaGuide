using Infrastructure.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository.Implements
{
    public class BaseRepository
    {
        private readonly HolaGuide_TestContext _dbContext;

        public HolaGuide_TestContext DbContext { get { return _dbContext; } }

        public BaseRepository(HolaGuide_TestContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
