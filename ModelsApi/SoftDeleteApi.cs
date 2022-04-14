using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class SoftDeleteApi: ApiBaseType
    {
        public bool? Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
