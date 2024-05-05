using System;
namespace DemoWebApi.Models
{
	public class Recipe
	{
		public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable<string> Direction { get; set; } = null!;
        public IEnumerable<string> Ingradient { get; set; } = null!;
        public DateTime Updated { get; set; }
    }
}

