using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}
