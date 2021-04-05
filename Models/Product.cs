using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Assignment.Models
{
    public class Product
    {
        private int v1;
        private string v2;
        private int v3;

        public Product()
        {
        }

        public Product(int v1, string v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        //public List<Order> Orders { get; set; }
    }
}
