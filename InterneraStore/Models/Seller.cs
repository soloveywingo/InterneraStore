using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterneraStore.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be more then 2 characters, but less then 20")]
        public string Name { get; set; }

        public virtual Company Company { get; set; } 
    }
}
