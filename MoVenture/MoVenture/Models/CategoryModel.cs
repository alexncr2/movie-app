using System;
using System.Collections.Generic;

namespace MoVenture.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            MovieList = new List<MinifiedMovie>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime SavedAt { get; set; }

        public User SavedBy { get; set; }

        public IList<MinifiedMovie> MovieList { get; set; }
    }
}
