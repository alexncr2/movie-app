using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class ActorModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
