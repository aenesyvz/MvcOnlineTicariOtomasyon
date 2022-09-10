using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Statement { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Code { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Staff { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Buyer { get; set; }
        public DateTime CargoDate { get; set; }
   
    }
}