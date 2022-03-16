using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class ProductApi: ApiBaseType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; }
        public int PartOfWarehouseId { get; set; }
        public int DeliveryNoteId { get; set; }
        public int? DepartNoteId { get; set; }
        public int? ProductTypeId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? SoftDeleteId { get; set; }
    }
}
