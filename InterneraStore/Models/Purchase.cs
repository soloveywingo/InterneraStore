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
        
        public int Quantity { get; set; }
        
        public virtual Customer Customer { get; set; }
        
        public virtual Seller Seller { get; set; }
        
        public virtual Product Product { get; set; }


    }
}
