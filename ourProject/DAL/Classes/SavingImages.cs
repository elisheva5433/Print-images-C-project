using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Classes
{
    public class SavingImages
    {
        
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public byte[] Images { get; set; }
        public int ProcessStatus { get; set; }
        public string Size { get; set; }

        public SavingImages() { }
        public SavingImages(int id, string orderCode, byte[] images, int processStatus,string size)
        {
            Id = id;
            OrderCode = orderCode;
            Images = images;
            Console.WriteLine(Images);
            
            ProcessStatus = processStatus;
        
            Size = size;
        }


    }
}
