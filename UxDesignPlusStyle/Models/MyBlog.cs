using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UxDesignPlusStyle.Models
{
    public class MyBlog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string imageUrl { get; set; }

        public string Author { get; set; }

        public DateTime DatePost { get; set; }

        public string Description { get; set; }

    }
}