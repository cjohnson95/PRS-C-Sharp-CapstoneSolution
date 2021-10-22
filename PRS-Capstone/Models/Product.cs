using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Capstone.Models {
    public class Product {

        public int Id { get; set; }
        [StringLength(30), Required]
        public string PartNbr { get; set; }
        [StringLength(30), Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }
        [StringLength(30), Required]
        public string Unit { get; set; } // unit is how many products you get for a price. Like you get a 6 pack of something for a price
        [StringLength(255)]
        public string PhotoPath { get; set; }
        [Required]
        public int VendorId { get; set; }


        public virtual Vendor Vendor { get; set; }
    }
}
