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
            book.ProductName = "book";
            book.ProductPrice = 20;

            ////creating product pen
            //Product Pen = new Product();
            //Pen.ProductName = "pen";
            //Pen.ProductPrice = 10;

            //creating order data
            Order _order = new Order();
            _order.OrderName = "first order";


            //first product of order
            OrderProduct _ordprod1 = new OrderProduct();
            _ordprod1.OrderedProduct = book;
            _ordprod1.ProductsOrdered = _order;
            _ordprod1.OrderDate = DateTime.Now;



            ////second product of order
            //OrderProduct _ordprod2 = new OrderProduct();
            //_ordprod2.OrderedProduct = Pen;
            //_ordprod2.ProductsOrdered = _order;
            //_ordprod2.OrderDate = DateTime.Now;

          

 

            DbDomain d = new DbDomain(_context);
             
            //Add to Product table
            d.ProdPost(book);
            //d.ProdPost(Pen);

            //Add to Order table
            d.OrderPost(_order);

            //add to order products
            d.OrdProd(_ordprod1);
            //d.OrdProd(_ordprod2);

            return View(_order);
        }
    }
}
