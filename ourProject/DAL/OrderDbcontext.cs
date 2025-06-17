using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class OrderDbcontext : DbContext
    {
        public DbSet<OrderManagment> OrderManagment {  get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Officer> Officer { get; set; }
        public DbSet<SavingImages> SavingImages { get; set; }
        public DbSet<Status> Status { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try { 
            optionsBuilder.UseSqlServer("Server=sqlsrv;Database=NewRREYPHONE;Trusted_Connection=True;Encrypt=False");
                 }
            catch(Exception e)
            {
                Console.WriteLine("error-database");
            }
         }


    }
}
