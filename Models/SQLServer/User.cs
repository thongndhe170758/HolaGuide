using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            UserSubcriptions = new HashSet<UserSubcription>();
        }

        public int Id { get; set; }
        public int Role { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<UserSubcription> UserSubcriptions { get; set; }
    }
}
