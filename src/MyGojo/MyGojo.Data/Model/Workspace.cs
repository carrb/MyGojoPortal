using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGojo.Data.Model
{
	public class Workspace
	{
		[Key]
		public int Id { get; set; }

		[StringLength(254)]
		public string Title { get; set; }

		[StringLength(254), Required]
		public string Url { get; set; }

		[Range(1, 1024)]
		public int Priority { get; set; }

		public bool IsVisible { get; set; }
		public bool IsEditable { get; set; }

		public ICollection<User> Users { get; set; }
	}
}

