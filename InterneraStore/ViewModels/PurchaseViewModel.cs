using InterneraStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterneraStore.ViewModels
{
    public class PurchaseViewModel
    {
        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        
        [Range(1, 100, ErrorMessage = "Invalid quantity")]
        public int Quantity { get; set; }

        public Purchase Purchase { get; set; }
    }
}