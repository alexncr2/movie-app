using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Category> Categories;
        public string Despription { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public double Rating { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Comment> Comments { get; set; }
        public int Status { get; set; }

        public Movie(string title, double rating)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Rating = rating;

            List<Category> tmp = new List<Category>
            {
                new Category("Comedy"),
                new Category("Action")
            };

            this.Categories = tmp;
        }
    }
}
