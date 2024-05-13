using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int? UserId { get; set; }
        public DateTime PostDate { get; set; }

        public virtual User? User { get; set; }
    }
}
