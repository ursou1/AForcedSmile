using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class Provider
    {
        public Provider()
        {
            DeliveryNotes = new HashSet<DeliveryNote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
    }
}
