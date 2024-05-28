using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;

        //Mô tả quyền lợi người dùng
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "float")]
        public double Price { get; set; }

        //Vĩnh viễn nếu là null
        public int? DurationDays { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new HashSet<UserSubscription>();
    }
}
