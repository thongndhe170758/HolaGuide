using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class UserSubcription
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SubcriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Subcription? Subcription { get; set; }
        public virtual User? User { get; set; }
    }
}
