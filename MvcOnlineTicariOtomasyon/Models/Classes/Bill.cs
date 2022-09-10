using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SerialNumber { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SequenceNumber { get; set; }
        
        public DateTime BillDate { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxAdministration { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(7)]
        public string BillTime { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryArea { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }
       
        public ICollection<BillPen> BillPens { get; set; }
        public decimal Total { get; set; }
    }
}