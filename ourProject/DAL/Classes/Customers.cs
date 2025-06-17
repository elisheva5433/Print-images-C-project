using System.ComponentModel.DataAnnotations;

namespace DAL.Classes
{
    public class Customers
    {
        [Key]
        public string CustomerCode { get; set; }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int phone { get; set; }
        public string Email { get; set; }
        
        public Customers() {
        this.Id = 0;
            this.Name = "hillel";
            this.CustomerCode = "434";
            this.phone = 99999;
            this.Email = string.Empty;
        }
        public Customers(int id, string customersCode, string name, int phone,string email)
        {

            Id = id;
            Name = name;
            CustomerCode = customersCode;
            this.phone = phone;
            this.Email = email;
        }
        public void toString()
        {
            Console.WriteLine(Id + " " + Name + " " + phone + " " + CustomerCode);
        }
    }
}



