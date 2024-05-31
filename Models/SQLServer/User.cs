using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Role { get; set; } = string.Empty; 

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varbinary(64)")]
        public byte[]? Password { get; set; } 

        //Dùng để làm nội dung chuyển khoản 
        [Required]
        public string Code { get; set;} = string.Empty;

        public bool? IsActivate { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
        public virtual ICollection<SaveService> SaveServices { get; set; } = new HashSet<SaveService>();
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new HashSet<UserSubscription>();
    }
}
