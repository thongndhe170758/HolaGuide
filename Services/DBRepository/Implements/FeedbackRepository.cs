using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using Models.Output_Models;
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
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(HolaGuide_TestContext holaGuide_TestContext) : base(holaGuide_TestContext) { }

        public List<Feedback> Gets(Expression<Func<Feedback, bool>> predicate)
        {
            return DbContext.Feedbacks.Include(f => f.User).Where(predicate).ToList();
        }

        public Feedback? Get(Expression<Func<Feedback, bool>> predicate)
        {
            return DbContext.Feedbacks.Include(f => f.User).FirstOrDefault(predicate);
        }

        public EntityOperationResponse<Feedback> Create(Feedback feedback)
        {
            try
            {
                DbContext.Feedbacks.Add(feedback);
                var result = DbContext.SaveChanges();
                if (result <= 0) return new EntityOperationResponse<Feedback> { Message = "Lỗi post feedback!", DataCount = 0 };
                return new EntityOperationResponse<Feedback> { Message = "success", DataCount = result, Data = feedback };
            }
            catch(Exception ex)
            {
                return new EntityOperationResponse<Feedback>{
                    Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                    DataCount = 0,
                };
            }
        }

        public EntityOperationResponse<Feedback> Remove(Feedback feedback)
        {
            try
            {
                DbContext.Feedbacks.Remove(feedback);
                var result = DbContext.SaveChanges();
                if (result <= 0) return new EntityOperationResponse<Feedback> { Message = "Lỗi post feedback!", DataCount = 0 };
                return new EntityOperationResponse<Feedback> { Message = "success", DataCount = result };
            }
            catch(Exception ex)
            {
                return new EntityOperationResponse<Feedback>
                {
                    Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                    DataCount = 0,
                };
            }
        }
    }
}
