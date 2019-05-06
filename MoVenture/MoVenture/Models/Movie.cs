using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public Guid Id                      { get; set; }

        [JsonProperty("title")]
        public string Title                 { get; set; }

        [JsonProperty("description")]
        public string Description           { get; set; }

        [JsonProperty("picture")]
        public string Picture               { get; set; }

        [JsonProperty("trailer")]
        public string Trailer               { get; set; }

        [JsonProperty("rating")]
        public float Rating                 { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories    { get; set; }

        [JsonProperty("actors")]
        public List<Actor> Actors           { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments       { get; set; }

        public string AllCategories
        {
            get { return GetAllCategories(); }
        }

        public string DisplayLength
        {
            get { return ""; }
        }

        private string GetAllCategories()
        {
            string tmp = "";
            foreach(Category c in Categories)
            {
                tmp += c.Name;
                tmp += " / ";
            }
            tmp = tmp.Remove(tmp.Length - 2);
            return tmp;
        }

    }
}
