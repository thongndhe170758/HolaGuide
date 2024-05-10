using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class Subcription
    {
        public Subcription()
        {
            UserSubcriptions = new HashSet<UserSubcription>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<UserSubcription> UserSubcriptions { get; set; }
    }
}
