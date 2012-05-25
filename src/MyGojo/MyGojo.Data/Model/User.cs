using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGojo.Data.Model
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[StringLength(254), Required]
		public string AdLogin { get; set; }

		[StringLength(254)]
		public string FirstName { get; set; }

		[StringLength(254)]
		public string LastName { get; set; }

		[StringLength(254)]
		public string Email { get; set; }

		public ICollection<SiteInfo> Sites { get; set; }
	}
}
