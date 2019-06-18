using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentMessage { get; set; }
        public Guid SavedBy { get; set; }
        public Guid MovieId { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public float Rating { get; set; }
    }
}
