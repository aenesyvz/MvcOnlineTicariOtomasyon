using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string  Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Statement { get; set; }
        [Column(TypeName ="bit")]
        public bool Status { get; set; }

    }
}