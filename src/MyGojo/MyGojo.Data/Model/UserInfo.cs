using System.Collections.Generic;

namespace MyGojo.Data.Model
{
	public class UserInfo
	{
		public int Id { get; set; }
		public string AdLogin { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public List<SiteInfo> Sites { get; set; }


        /// Constructors
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
