﻿using System;
using System.Collections.Generic;

namespace Models.SQLServer
{
    public class Service
    {
        public Service()
        {
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int? LocationId { get; set; }
        public string? Title { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Location? Location { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}