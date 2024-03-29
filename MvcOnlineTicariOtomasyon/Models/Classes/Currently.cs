﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Currently
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string City { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }
        public bool Status { get; set; }
        public ICollection<SaleMovement> SaleMovements { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        public string Password { get; set; }
    }
}