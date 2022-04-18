using System;

namespace ISRPO.Fourth.Domain.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}