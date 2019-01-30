using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterneraStore.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35,MinimumLength = 2, ErrorMessage ="Name should be more then 2 characters, but less then 35")]
        public string Name { get; set; }
    }
}
