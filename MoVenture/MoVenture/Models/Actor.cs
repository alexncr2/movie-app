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
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
