﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Capstone.Models {
    public class Request {

        public int Id { get; set; }
        [StringLength(80), Required]
        public string Description { get; set; }
        [StringLength(80), Required]
        public string Justification  { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [StringLength(20), Required]
        public string DeliveryMode { get; set; } = "Pickup";
        [StringLength(10), Required]
        public string Status { get; set; } = "New";
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; } = 0;
        [Required]      
        public int UserId { get; set; }


        public virtual IEnumerable<Requestline> Requestlines { get; set; }
        public virtual User User { get; set; }
    }
}
