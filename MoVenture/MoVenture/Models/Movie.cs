using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Movie
    {
        public Guid Id                      { get; set; }
        public string Title                 { get; set; }
        public string Description           { get; set; }
        public string Picture               { get; set; }
        public string Trailer               { get; set; }
        public float Rating                 { get; set; }
        public DateTime LaunchDate          { get; set; }
        public List<Category> Categories    { get; set; }
        public List<Actor> Actors           { get; set; }
        public List<Comment> Comments       { get; set; }
        public int Status                   { get; set; }

        public Movie(string title, float rating, string description, List<Category> categs)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Rating = rating;
            this.Description = description;
            this.Categories = categs;

            List<Actor> tmp = new List<Actor>
            {
                new Actor("BoJack", "Horseman"),
                new Actor("Leonardo", "DiCaprio"),
                new Actor("Jennifer", "Aniston")
            };

            List<Comment> tmp2 = new List<Comment>
            {
                new Comment("This movie good"),
                new Comment("This movie no good"),
                new Comment("is ok")
            };
            this.Actors = tmp;
            this.Comments = tmp2;
        }

        public string GetCategories()
        {
            string tmp = "";
            try
            {
                foreach (Category c in Categories)
                {
                    tmp += c.Name;
                    tmp += ", ";
                }
                return tmp.Remove(tmp.Length - 2);
            }
            catch (NullReferenceException e)
            {
                return "No category info";
            }
        }

        public string GetActors()
        {
            string tmp = "";
            try
            {
                foreach (Actor a in Actors)
                {
                    tmp += a.FirstName;
                    tmp += ", ";
                }
                return tmp.Remove(tmp.Length - 2);
            }
            catch (NullReferenceException e)
            {
                return "No actors info";
            }
        }
    }
}
