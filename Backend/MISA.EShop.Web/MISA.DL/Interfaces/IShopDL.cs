using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IShopDL
    {
        public string GetHighestCode();
        public IEnumerable<Shop> CheckDuplicate(string name, string value);
        public IEnumerable<Shop> GetShopSortPage(int page, string filter, int desc);
    }
}
