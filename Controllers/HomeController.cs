using EF_Assignment.DataAcees;
using EF_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using EF_Assignment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            book.ProductId = 1;
            book.ProductName = "book";
            book.ProductPrice = 20;

            //creating product pen
            Product Pen = new Product(2, "pen", 10);

            
            //first product of order
            OrderProduct _ordprod1 = new OrderProduct();
            _ordprod1.orderId = 123;
            _ordprod1.productId = 1;
            //second product of order
            OrderProduct _ordprod2 = new OrderProduct();
            _ordprod2.orderId = 123;
            _ordprod2.productId = 2;

            //create list of order products
            List<OrderProduct> _ordprod = new List<OrderProduct>();
            _ordprod.Add(_ordprod1);
            _ordprod.Add(_ordprod2);

            //creating order data
            Order _order = new Order();
            _order.OrderId = 1234;
            _order.OrderName = "first order";
            _order.OrderProducts = _ordprod;

            DbDomain d = new DbDomain(_context);
            //Add to Product table
            d.ProdPost(book);
            d.ProdPost(Pen);
            //Add to Order table
            d.OrderPost(_order);

            return View(_order);
        }
    }
}
