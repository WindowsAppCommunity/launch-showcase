using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LaunchShowcase.Sdk.Models
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
        }

        public Tag()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public List<Project> Projects { get; set; }
    }
}
