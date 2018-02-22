using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity cannot be 0")]
        public int Quantity { get; set; }

        [Required]
        public bool IsInStock { get; set; }
    }
}