using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Assignment.Models
{
    public class OrderProduct:DbContext
    {
        public OrderProduct()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(o => new { o.orderId, o.productId });
        }
        //[Key, Column(Order = 0)]
        public int orderId { get; set; }
        //[Key, Column(Order = 1)]
        public int productId { get; set; }
    }
}
