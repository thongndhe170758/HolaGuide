using Models.Output_Models;
using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface IFeedbackRepository
    {
        public List<Feedback> Gets(Expression<Func<Feedback, bool>> predicate);
        public Feedback? Get(Expression<Func<Feedback, bool>> predicate);
        public EntityOperationResponse<Feedback> Create(Feedback feedback);
        public EntityOperationResponse<Feedback> Remove(Feedback feedback);
    }
}
