using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public partial class SaveService
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? UserId { get; set; }
        public DateTime SaveDate { get; set; }

        public virtual Service? Service { get; set; }
        public virtual User? User { get; set; }
    }
}
