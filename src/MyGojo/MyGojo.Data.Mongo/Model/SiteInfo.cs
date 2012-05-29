using System.Collections.Generic;
using DreamSongs.MongoRepository;
using Gojo.Core.Data.Generators;


namespace MyGojo.Data.Mongo.Model
{
    public class SiteInfo : Entity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }
        public int Priority { get; set; }

        public List<UserInfo> Users { get; set; }


        /// Constructor
        /// 
        public SiteInfo() : this("") {}
        public SiteInfo(string siteUrl) { InitMembers(siteUrl); }


        /// Leverage automatic properties...initialize appropriate members.
        /// 
        private void InitMembers(string url)
        {
            Title = string.Empty;
            Url = url;
            IsVisible = true;
            IsEditable = true;
            Priority = CryptographicallyRandomIntegerGenerator.GenerateCryptographicallyRandomPositiveInt32InRange(1, 2048);
            Users = new List<UserInfo>();
        }
    }
}
