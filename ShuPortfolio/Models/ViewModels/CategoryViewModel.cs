using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ShuPortfolio.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Pleas enter category name")]
        public string Name { get; set; }

        public  string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public IFormFile File { get; set; }

        public ICollection<Work> Works { get; set; }
    }
}
