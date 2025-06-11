using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
     public interface IReadImagesAdress
    {
        public void Reader_picture(int id,string selectedOption);
        public Customers customerDetails(int id);
        public double sumPictures(string selectedOption);
    }
}
