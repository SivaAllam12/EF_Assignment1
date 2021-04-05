using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Assignment.Models
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }
        public string OrderName { get; set; }
        [NotMapped]
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
