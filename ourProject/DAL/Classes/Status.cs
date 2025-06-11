using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Status
    {
        [Key]
        public int Id { get; set; } 
        public int ProcessStatus { get; set; }
        public string StatusDescription { get; set; }

        public Status() { }
        public Status(int id, int processStatus, string statusDescription)
        {
            Id = id;
            ProcessStatus = processStatus;
            StatusDescription = statusDescription;
        }


       
    }
}
