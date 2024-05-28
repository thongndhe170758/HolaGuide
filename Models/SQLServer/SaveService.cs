using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class SaveService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int? ServiceId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime SaveDate { get; set; } = DateTime.Today;

        public virtual Service? Service { get; set; }
        public virtual User? User { get; set; }
    }
}
