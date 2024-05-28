using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double Longtitude { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double Latitude { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}
