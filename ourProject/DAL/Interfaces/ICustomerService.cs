//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BLL;

namespace DAL.Interfaces;
public interface ICustomerService
{
   void CreateCustomer(int id, string name, int phone, string email);
}

