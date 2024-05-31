using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

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

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "float")]
        public double Price { get; set; }

        //Vĩnh viễn nếu là null
        public int? DurationDays { get; set; }

        //Quyền lợi người dùng
        [Required]
        public string UserRights { get; set; } = string.Empty;

        //0 - deactivated, 1 - activated
        [Required]
        public bool Status { get; set; } = false;

        public string ToMoneyFormat()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");
            string formattedPrice = Price.ToString("C0", culture); // "C0" for currency format without decimal places
            return formattedPrice;
        }

        public List<string> GetUserRights()
        {
            return UserRights.Trim().Split(';').ToList();
        }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; } = new HashSet<UserSubscription>();
    }
}
