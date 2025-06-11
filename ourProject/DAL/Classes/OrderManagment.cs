//using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Classes
{
    public class OrderManagment
    {
        public int Id { get; set; }
        [Key]
        public string OrderCode { get; set; }
        public int ProcessStatus { get; set; }
        public string OfficerCode { get; set; }
        public string CustomerCode { get; set; }
        public string SizePicture { get; set; }

        public OrderManagment() { }
        public OrderManagment(int id, string orderCode, int processStatus, string officerCode, string customerCode,string sizePicture)
        {
            Id = id;
            OrderCode = orderCode;
            ProcessStatus = processStatus;
            OfficerCode = officerCode;
            CustomerCode = customerCode;
            SizePicture = sizePicture;
        }
        public void toString()
        {
            Console.WriteLine("=======================");
            Console.WriteLine(Id+" "+OrderCode+" "+OfficerCode);
        }

    }
}

