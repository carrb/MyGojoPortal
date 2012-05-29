using System.Collections.Generic;

namespace MyGojo.Data.Model
{
    public class SiteInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }
        public int Priority { get; set; }

        public List<UserInfo> UserAccounts { get; set; }


        /// Constructor
        /// 
        public SiteInfo(string siteUrl)
        {
            InitMembers(siteUrl);
        }


        /// To leverage automatic properties, initialize appropriate members here.
        /// 
        private void InitMembers(string url)
        {
            Title = string.Empty;
            Url = url;
            IsVisible = true;
            IsEditable = true;
            Priority = 1;
            UserAccounts = new List<UserInfo>();
        }
    }
}
