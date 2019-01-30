using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterneraStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Customer_Id { get; set; }

        [Required]
        public int Seller_Id { get; set; }

        [Required]
        public int Product_Id { get; set; }


    }
}
