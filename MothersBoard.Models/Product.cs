using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MothersBoard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string ImgPathCompanyLogo {get;set;}
        public string ImgPath { get; set; }
        public string Category { get; set; }
        public int NumberOfStar { get; set; }
        public string Description { get; set; }
    }
}
