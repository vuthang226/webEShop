using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IShopBL:IBaseBL<Shop>
    {
        public string GetHighestCodeAddOne();
        public IEnumerable<Shop> GetShopSortPage(int page, string filter, int desc);
    }
}
