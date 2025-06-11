using DAL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Mvc;
//using ourProject.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
//using DAL;
using BLL.Interfaces;
using BLL.Classes;
using DAL.Classes;
using System.Numerics;

namespace ourProject.Controllers
{
    public class HomeController : Controller
    {
        public static int idCustomer;
        public static string Email;
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IReadImagesAdress _readImagese;
        private readonly IShowOrderList _showOrderList;
        private readonly SendEmail _sendEmail;

        //private readonly OrderDbcontext _context;,OrderDbcontext context
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService, IReadImagesAdress readImages,IShowOrderList showOrderList, SendEmail sendEmail)
        {
            _logger = logger; 
            _customerService = customerService;
            _readImagese = readImages;
            _showOrderList = showOrderList;
            _sendEmail = sendEmail; 
            //_context = context;

        }
        



        //public CustomerController(ICustomerService customerService)
        //{
        //}
    
    [HttpPost]
        public IActionResult CreateCustomer(int id,string name,int phone, string email)
        {
            ViewBag.Name = name; //אני שואבת את השם שלו
            ViewBag.Phone = phone; // אני שואבת את הפלאפון שלו
            
            Console.WriteLine("fghjkl");
            idCustomer = id;
            Email = email;
            _customerService.CreateCustomer(id, name, phone,email);
            return View("Privacy");
            
        }

        [HttpPost]
        public IActionResult properties()
        {
            Console.WriteLine("successfuly properties!!!!!");
            

            return View();

        }
        public IActionResult Reader_picture()
        {

            Console.WriteLine("successfuly properties!!!!!");


            return View();

        }


        //[HttpGet]1
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult HomePage()
        {
            Console.WriteLine("bvbbbbC");
            return View();
        }

        public IActionResult CustomerLogin()
        {
            Console.WriteLine("bvbbbbC");
            return View();
        }

        public IActionResult OfficerLogin()
        {
            Console.WriteLine("ofiicer login");
            return View();
        }

        public IActionResult OfficerView(String OfficerCode)
        {
            Console.WriteLine("555555555555555555555555555555555555555id 1: " + OfficerCode);
            if (OfficerCode == null) { return View("OfficerLogin"); }
            
            List<OrderManagment> orders= _showOrderList.selectOrders(OfficerCode);
            return View(orders);
        }

        public IActionResult orderSuccessfull(int id=0)
        {
            _showOrderList.orderSuccessfull(id);
            //Console.WriteLine(sum);
            Customers c = _readImagese.customerDetails(idCustomer);
            _sendEmail.SendToEmail(Email,"Photo", c);
            return View("HomePage");
        }

      
        public IActionResult Privacy()
        {

            return View();
        }
        public IActionResult SelectImages()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ReadImages(string selectedOption)
        {
            //Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&"+name + " " + phone);
            //ViewBag.Name2 = name; //אני שואבת את השם שלו
            //ViewBag.Phone2 = phone;
            //ViewBag.sum = 100; // לדוגמה, הגדרה של סכום כלשהו

            _readImagese.Reader_picture(idCustomer, selectedOption);
            Customers c = _readImagese.customerDetails(idCustomer);
            double sum = _readImagese.sumPictures(selectedOption);
            Console.WriteLine(sum);
            ViewBag.Name=c.Name;
            ViewBag.Phone = c.phone;
            ViewBag.sum = sum;
            Console.WriteLine(ViewBag.Name + " ," + ViewBag.Phone);
            return View("Invoice");
            //ViewBag.Name = name; //אני שואבת את השם שלו
            //ViewBag.Phone = phone;
            ////ViewBag.Email = email;
            //_readImagese.Reader_picture(idCustomer,selectedOption);
            //return View("Invoice");
        }
        //public IActionResult Invoice(string selectedOption, int id, string name, int phone, string email)
        //{
        //    //ViewBag.Name = name; //אני שואבת את השם שלו
        //    //ViewBag.Phone = phone;
        //    //ViewBag.Email = email;

        //    return View();
        //}
        // GET: /Customer/GetCustomerById/5
        [HttpGet]
        public IActionResult GetCustomerById(int idCustomer)
        {
            // Assuming you have a service to get customer details
            //..var customer = customerService.GetCustomerById(idCustomer);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //return PartialView("_CustomerDetails", customer);
            return View();
        }
    }
}




  

