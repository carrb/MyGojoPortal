using System;
using System.ComponentModel.DataAnnotations;

namespace MyGojo.Data.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(254), Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }


        /* Currently setting CreatedAt property before save in PostsController!!!
         * Not sure if that is the way I ultimately want to handle this.

        /// Creates valid domain object
        /// A no argument public constructor must be available for NHibernate
        public Post()
        {
            InitMembers();
        }

        /// Since we want to leverage automatic properties, init appropriate members here.
        /// 
        private void InitMembers()
        {
            CreatedAt = DateTime.Now;
        }
         * 
         */
    }
}
