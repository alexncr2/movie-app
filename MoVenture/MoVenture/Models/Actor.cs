using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }

        public Actor(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
