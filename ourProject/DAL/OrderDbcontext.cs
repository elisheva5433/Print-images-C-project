using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using Microsoft.EntityFrameworkCore;
//using ourProject.Models;
//using DAL;
namespace DAL
{
    public class OrderDbcontext : DbContext
    {
       //public OrderDbcontext(DbContextOptions<OrderDbcontext> options) : base(options) { }
        public DbSet<OrderManagment> OrderManagment {  get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Officer> Officer { get; set; }
        public DbSet<SavingImages> SavingImages { get; set; }
        public DbSet<Status> Status { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)

        //{
        //    modelBuilder.Entity<Customers>()
        //    .HasKey(c => c.CustomersCode); // הגדר את המפתח הראשי באמצעות Fluent API
        //    modelBuilder.Entity<OrderManagment>()
        //    .HasKey(c => c.OrderCode);
        //    modelBuilder.Entity<Officer>()
        //    .HasKey(c => c.OfficerCode); // הגדר את המפתח הראשי באמצעות Fluent API
        //    modelBuilder.Entity<SavingImages>()
        //    .HasKey(c => c.Id);
        //    modelBuilder.Entity<Status>()
        //    .HasKey(c => c.Id);
        //}

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
