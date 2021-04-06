using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Assignment.Models
{
    public class OrderProduct
    {
        public OrderProduct()
        {

        }
        public int Id { get; set; }
        public Order ProductsOrdered { get; set; }
        public Product OrderedProduct { get; set; }
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
