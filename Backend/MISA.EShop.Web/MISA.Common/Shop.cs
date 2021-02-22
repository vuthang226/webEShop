using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Shop
    {
        public Guid ShopId { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopPhone { get; set; }
        public string ShopTaxCode { get; set; }
        public string ShopNation { get; set; }
        public string ShopCity { get; set; }
        public string ShopDistrict { get; set; }
        public string ShopWard { get; set; }
        public string ShopStreet { get; set; }
        public string ShopStatus { get; set; }
    }
}
