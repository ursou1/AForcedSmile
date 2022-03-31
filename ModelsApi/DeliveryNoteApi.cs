using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class DeliveryNoteApi: ApiBaseType
    {
        public int Number { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProviderId { get; set; }


        public ProviderApi Provider { get; set; }//для вывода св-ва Provider.Name
    }
}
