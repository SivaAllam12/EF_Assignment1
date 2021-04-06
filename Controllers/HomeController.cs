using EF_Assignment.DataAcees;
using EF_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using EF_Assignment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            //creating product book
            Product book=new Product();
            book.ProductName = "book";
            book.ProductPrice = 20;

            //creating order data
            Order _order = new Order();
            _order.OrderName = "first order";
            //second order
            Order _order2 = new Order();
            _order2.OrderName = "second order";

            //first product of order
            OrderProduct _ordprod1 = new OrderProduct();
            _ordprod1.OrderedProduct = book;
            _ordprod1.ProductsOrdered = _order;
            _ordprod1.Quantity = 2;
            _ordprod1.OrderDate = DateTime.Now;



            //second product of order
            OrderProduct _ordprod2 = new OrderProduct();
            _ordprod2.OrderedProduct = book;
            _ordprod2.ProductsOrdered = _order2;
            _ordprod2.Quantity = 4;
            _ordprod2.OrderDate = DateTime.Now;

            //Create object to push to database
            DbDomain d = new DbDomain(_context);

            //Add to Product table
            d.ProdPost(book);
            //d.ProdPost(Pen);

            ////Add to Order table
            d.OrderPost(_order);
            d.OrderPost(_order2);

            ////add to order products
            d.OrdProd(_ordprod1);
            d.OrdProd(_ordprod2);

            //orders where a product is sold
            IQueryable<OrderProduct> soldproductorders = d._context.OrderProducts
                .Include(c=>c.OrderedProduct).Where(c=>c.OrderedProduct==book);

            //list of all orders where a product is sold
            List<OrderProduct> SelectedSoldProductOrders = soldproductorders.ToList();

            //Orders where a given product sold maximum
            OrderProduct maxsoldproductorders = d._context.OrderProducts
              .Include(c => c.OrderedProduct).Where(c => c.OrderedProduct == book).OrderByDescending(x=>x.Quantity).FirstOrDefault();

            return View(_order);
        }
    }
}
