using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gojo.Core.Data.Generators;

namespace SiteLinks
{
    public class Site
    {
        public int Id { get; set; }
        public int Guid { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }

        public ICollection<AccountLogin> UserAccounts { get; set; }


        public Site(string siteUrl)
        {
            InitMembers(siteUrl);
        }


        /// To leverage automatic properties, initialize appropriate members here.
        private void InitMembers(string url)
        {
            Id = CryptographicallyRandomIntegerGenerator.GetCryptographicallyRandomInt32Number();

            Url = url;
            UserAccounts = new List<AccountLogin>();
        }
    }
}
