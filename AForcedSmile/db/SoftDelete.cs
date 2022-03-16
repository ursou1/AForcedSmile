using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class SoftDelete
    {
        public SoftDelete()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
