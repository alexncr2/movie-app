using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public User SavedBy { get; set; }
    }
}
