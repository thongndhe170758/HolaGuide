using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class Image
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string Value { get; set; } = null!;

        public virtual Service? Service { get; set; }
    }
}
