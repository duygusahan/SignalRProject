﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.EntityLayer.Concrete
{
    public class Basket
    {
        public int BasketId { get; set; }
       
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
