using System;
using System.Collections.Generic;
using Gojo.Core.Data.Generators;

namespace MyGojo.Data.Model
{
    public class SiteInfo
    {
        public int Id { get; set; }
        public Guid SiteGuid { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> UserAccounts { get; set; }


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
            Id = CryptographicallyRandomIntegerGenerator.GetCryptographicallyRandomInt32Number();
            SiteGuid = Guid.NewGuid();
            Url = url;
            UserAccounts = new List<string>();
        }
    }
}
