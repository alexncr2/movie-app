using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Movie : MinifiedMovie
    {
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public string TrailerUrl { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public List<ActorModel> Actors { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
