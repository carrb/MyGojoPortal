using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamSongs.MongoRepository;
using Gojo.Core.Data.Generators;

namespace MyGojo.Data.Model
{
    public class Announcement : Entity
    {
        public string Title { get; set; }
        public string Content{ get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }
        public int Priority { get; set; }

        /// Constructors
        /// 
        public Announcement() : this("") {}
        public Announcement(string title) { InitMembers(title); }


        /// Leverage automatic properties...initialize appropriate members.
        /// 
        private void InitMembers(string title)
        {
            Title = title;
            Content = "## Content uses Markdown Syntax";
            IsVisible = true;
            IsEditable = true;
            Priority = CryptographicallyRandomIntegerGenerator.GenerateCryptographicallyRandomPositiveInt32InRange(1, 20);

        }
    }
}
