using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Path { get; set; } = string.Empty;

        public virtual Service? Service { get; set; }
    }
}
