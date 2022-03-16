using System;
using System.Collections.Generic;

#nullable disable

namespace AForcedSmile.db
{
    public partial class Client
    {
        public Client()
        {
            DepartNotes = new HashSet<DepartNote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DepartNote> DepartNotes { get; set; }
    }
}
