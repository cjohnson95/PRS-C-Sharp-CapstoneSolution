﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PRS_Capstone.Models {
    public class Requestline {

        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;

        public virtual Product Product { get; set; }
        [JsonIgnore]
        public virtual Request Request { get; set; }
    }
}
