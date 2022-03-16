using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class PartOfWarehouse
    {
        public PartOfWarehouse()
        {
            ProductPartOfWarehouses = new HashSet<ProductPartOfWarehouse>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ProductPartOfWarehouse> ProductPartOfWarehouses { get; set; }
    }
}
