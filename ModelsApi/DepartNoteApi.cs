using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class DepartNoteApi: ApiBaseType
    {
        public int Number { get; set; }
        public DateTime DepartDate { get; set; }
        public int ClientId { get; set; }
    }
}
