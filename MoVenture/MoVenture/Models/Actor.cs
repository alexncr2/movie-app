﻿using System;
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

        public Actor(string fname, string lname)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = fname;
            this.LastName = lname;
            this.Status = 0;
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
