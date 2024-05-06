using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace DemoWebApi.Models
{
	public record Recipe
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonProperty("recipe_id")]
        public string RecipeId { get; set; } = null!;

        [Required]
		public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable<string> Direction { get; set; } = null!;
        public IEnumerable<string> Tags { get; set; } = null!;

        [Required]
        public IEnumerable<Ingradient> Ingradients { get; set; } = null!;
        public DateTime Updated { get; set; }
    }

    public record Ingradient
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public string Unit { get; set; } = null!;
    }
}

