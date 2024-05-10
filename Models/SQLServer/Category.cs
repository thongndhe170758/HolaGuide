using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class Category
    {
        public Category()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
