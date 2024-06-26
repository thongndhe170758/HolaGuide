﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Service")]
        public int? ServiceId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PostDate { get; set; } = DateTime.Today;

        public virtual User? User { get; set; }
        public virtual Service? Service { get; set; }
    }
}
