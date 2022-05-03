using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class ProductPartOfWarehouseApi: ApiBaseType
    {
        public int ProductId { get; set; }
        public int PartOfWarehouseId { get; set; }
        public int ProductCount { get; set; }
    }
}
