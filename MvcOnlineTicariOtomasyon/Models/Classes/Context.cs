using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Currently> Currentlies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BillPen> BillPens { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<SaleMovement> SaleMovements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDo> toDos { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}