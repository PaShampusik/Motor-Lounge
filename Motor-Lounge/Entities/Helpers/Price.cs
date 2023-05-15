﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Lounge.Entities.Helpers
{
    public class Price
    {
        public long IndividualPrice { get; set; }
        public long CorporationPrice { get; set; }
        public Price(long _individualPrice, long _corporationPrice)
        {
            IndividualPrice = _individualPrice;
            CorporationPrice = _corporationPrice;
        }
        public Price() { }
    }
}
