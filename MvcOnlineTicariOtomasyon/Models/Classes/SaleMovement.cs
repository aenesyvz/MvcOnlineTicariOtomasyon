using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SaleMovement
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CurrentlyId { get; set; }
        public virtual Currently Currently { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}