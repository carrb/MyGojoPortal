using System.Collections.Generic;
using DreamSongs.MongoRepository;


namespace MyGojo.Data.Mongo.Model
{
	public class UserInfo : Entity
	{
		public string AdLogin { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public List<SiteInfo> Sites { get; set; }


        /// Constructors
        /// 
        public UserInfo() : this("") {}
        public UserInfo(string adLogin) { InitMembers(adLogin); }


        /// Leverage automatic properties...initialize appropriate members..
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
