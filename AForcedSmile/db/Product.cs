using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class Product
    {
        public Product()
        {
            ProductPartOfWarehouses = new HashSet<ProductPartOfWarehouse>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; }
        public int? DeliveryNoteId { get; set; }
        public int? DepartNoteId { get; set; }
        public int? ProductTypeId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? SoftDeleteId { get; set; }

        public virtual DeliveryNote DeliveryNote { get; set; }
        public virtual DepartNote DepartNote { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual SoftDelete SoftDelete { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<ProductPartOfWarehouse> ProductPartOfWarehouses { get; set; }
    }
}
