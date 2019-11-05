using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UxDesignPlusStyle.Models
{
    public class MyPortfolio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        public string imageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public MyPortfolio() {
            imageUrl = "~/Content/images/me.jpg";
        }
    }
}