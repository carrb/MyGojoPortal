using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gojo.Core.Data.Generators;

namespace MyGojo.Data.Model
{
    public class SiteInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }

        [Range(1, 2048)]
        public int Priority { get; set; }

        

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
            Title = string.Empty;
            Url = url;
            IsVisible = true;
            IsEditable = true;
            Priority = 1;
            UserAccounts = new List<string>();
        }
    }
}
