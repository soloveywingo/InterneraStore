using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterneraStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be more then 2 characters, but less then 20")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price, use dot to split")]
        [DisplayName("Price ($)")]
        public decimal Price { get; set; }
    }
}
