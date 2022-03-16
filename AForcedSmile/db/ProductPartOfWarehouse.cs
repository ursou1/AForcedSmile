using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class ProductPartOfWarehouse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PartOfWarehouseId { get; set; }

        public virtual PartOfWarehouse PartOfWarehouse { get; set; }
        public virtual Product Product { get; set; }
    }
}
