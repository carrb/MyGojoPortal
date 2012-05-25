using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGojo.Data.Model
{
	public class UserInfo
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

		public List<SiteInfo> Sites { get; set; }


        /// Constructor
        /// 
        public UserInfo(string adLogin)
        {
            InitMembers(adLogin);
        }


        /// To leverage automatic properties, initialize appropriate members here.
        /// 
        private void InitMembers(string adLogin)
        {
            AdLogin = adLogin;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Sites = new List<SiteInfo>();
        }
	}
}
