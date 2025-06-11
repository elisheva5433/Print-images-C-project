using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes;
public class Officer
{
    
    [Key]
    public string OfficerCode { get; set; } 
    public int Id;
  
    public string Name { get; set; }
    public int Phone { get; set; }

    public Officer() { }
    public Officer(int id, string officerCode, string Name, int phone)
    {
        Id = id;
        OfficerCode = officerCode;
        this.Name = Name;
        Phone = phone;
    }
    

}

