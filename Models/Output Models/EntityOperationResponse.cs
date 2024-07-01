using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Output_Models
{
    public class EntityOperationResponse<T> where T : class
    {
        public string Message { get; set; }
        public int DataCount { get; set; }
        public T Data { get; set; }
    }
}
