using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class UserSubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Subscription")]
        public int? SubscriptionId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsPurchased { get; set; } = false;

        public virtual Subscription? Subscription { get; set; }
        public virtual User? User { get; set; }
    }
}
