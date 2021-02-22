
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerMemberCardCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int? CustomerGender { get; set; }
        public DateTime? CustomerBirth { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string CustomerCompanyName { get; set; }
        public string CustomerCompanyTaxCode { get; set; }
        public string CustomerAddress { get; set; }
    }
}
