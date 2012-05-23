using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gojo.Core.Data.Generators;

namespace SiteLinks
{
    public class AccountLogin
    {
        public int Id { get; set; }

        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public AccountLogin()
        {
            InitMembers();
        }


        /// To leverage automatic properties, initialize appropriate members here.
        private void InitMembers()
        {
            Id = CryptographicallyRandomIntegerGenerator.GetCryptographicallyRandomInt32Number();
        }
    }
}
