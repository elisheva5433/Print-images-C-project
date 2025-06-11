using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IShowOrderList
    {
        public List<OrderManagment> selectOrders(String officerCode);
        public void orderSuccessfull(int id);
    }
}
