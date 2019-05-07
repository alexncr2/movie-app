using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<Movie> Movies { get; set; }
        public int Status { get; set; }
    }
}
