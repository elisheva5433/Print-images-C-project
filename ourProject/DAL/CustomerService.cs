using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL;


public class CustomerService : ICustomerService
{

    public string GenerateUniqueOrderId()

    {
        var context = new OrderDbcontext();
        int customerCode;
        do
        {
            customerCode = new Random().Next(10000, 99999);

        } while (context.Customers.Any(o => o.Id == customerCode));
        string code = customerCode.ToString();//convert to string
        return code;

    }


    public void CreateCustomer(int id, string name,int phone,string email)
    

        {
            if (name == null)
            {
                Console.WriteLine("name cannot be null");
            }
            Console.WriteLine(name);
            try {
           using (var context = new  OrderDbcontext())

            {
                
                String code = GenerateUniqueOrderId();
                Console.WriteLine("code: "+code);
                Customers Customer = new Customers(id, code, name, phone,email);
                Customer.toString();
                context.Customers.Add(Customer);
                context.SaveChanges();
                Console.WriteLine("seccsfulllllllll!");
               

            }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }


    }



