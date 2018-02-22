using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Required]
        public bool IsInStock { get; set; }

    }
}