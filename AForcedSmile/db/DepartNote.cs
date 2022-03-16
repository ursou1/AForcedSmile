using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class DepartNote
    {
        public DepartNote()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DepartDate { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
