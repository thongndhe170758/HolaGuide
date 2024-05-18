using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            SaveServices = new HashSet<SaveService>();
            Services = new HashSet<Service>();
            UserSubcriptions = new HashSet<UserSubcription>();
        }

        public int Id { get; set; }
        public int Role { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsSubcripted { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<SaveService> SaveServices { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<UserSubcription> UserSubcriptions { get; set; }
    }
}
