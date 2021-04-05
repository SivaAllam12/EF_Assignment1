using EF_Assignment.DataAcees;
using EF_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Assignment.Domain
{
    public class DbDomain
    {

        public ApplicationDbContext _context;
        public DbDomain(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public void OrderPost(Order ord1)
        {
            _context.Orders.Add(ord1);
            
            _context.SaveChanges();

        }
        public void ProdPost(Product p1)
        {
            _context.Products.Add(p1);

            _context.SaveChanges();

        }
        public void OrdProd(OrderProduct op)
        {
            _context.OrderProducts.Add(op);

            _context.SaveChanges();
        }
    }
}
