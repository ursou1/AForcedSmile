using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class DeliveryNoteView
    {
        public DeliveryNoteApi DeliveryNote { get; set; }
        public ProviderApi Provider { get; set; }
    }
}
