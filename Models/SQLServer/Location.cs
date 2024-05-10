using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class Location
    {
        public Location()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
