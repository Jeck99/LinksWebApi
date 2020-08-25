using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinksWebApplication.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [Display(Name = "Link src")]
        public string src { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        public int UserId { get; set; }
    }
}