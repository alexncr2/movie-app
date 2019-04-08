using System;

namespace MoVenture.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Category(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }
    }
}
