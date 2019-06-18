using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
