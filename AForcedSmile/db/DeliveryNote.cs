using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class DeliveryNote
    {
        public DeliveryNote()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
