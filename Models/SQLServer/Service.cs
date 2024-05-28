using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.SQLServer
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Price { get; set; } = string.Empty;

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int? OwnerId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Today;

        [Required]
        [Column(TypeName = "char(10)")]
        public string ContactNumber { get; set; } = string.Empty;

        public bool? IsVerified { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Location? Location { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();  
        public virtual ICollection<SaveService> SaveServices { get; set; } = new HashSet<SaveService>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();

        public string GetFullPrice()
        {
            return $"{Price}đ";
        }
    }
}
