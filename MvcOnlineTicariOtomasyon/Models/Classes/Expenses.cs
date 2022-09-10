using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Statement { get; set; }
        public DateTime ExponseDate { get; set; }
        public decimal Total { get; set; }
    }
}