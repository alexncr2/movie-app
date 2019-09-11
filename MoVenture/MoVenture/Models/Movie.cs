using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("picture")]
        public string PictureUrl { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        public int Length { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public DateTime LaunchDate { get; set; }

        [JsonProperty("trailer")]
        public string TrailerUrl { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        public DateTime SavedAt { get; set; }

        [JsonProperty("actors")]
        public List<ActorModel> Actors { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }


        [JsonProperty("categories")]
        public List<Tag> Tags { get; set; }



        public Guid CreatedBy { get; set; }
        public CategoryModel MainCategory { get; set; }

        public string AllCategories
        {
            get
            {
                string toReturn = "";
                foreach (Tag t in Tags)
                {
                    toReturn += t.Name + " / ";
                }
                return toReturn.Substring(toReturn.Length - 2);
            }
        }
    }
}
