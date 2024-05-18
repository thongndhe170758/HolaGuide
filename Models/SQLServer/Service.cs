using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public partial class Service
    {
        public Service()
        {
            Images = new HashSet<Image>();
            SaveServices = new HashSet<SaveService>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
        public int? LocationId { get; set; }
        public string? Title { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ContactNumber { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Location? Location { get; set; }
        public virtual User? Owner { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<SaveService> SaveServices { get; set; }
    }
}
