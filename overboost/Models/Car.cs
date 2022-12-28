using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace overboost.Models
{
    public class Car
    {
        public string? Id { get; set; }
        public int? Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        [JsonPropertyName("img")]
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int[]? Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
