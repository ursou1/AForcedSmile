using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.db
{
    public partial class DeliveryNote
    {
        public static explicit operator DeliveryNoteApi(DeliveryNote deliveryNote)
        {
            if (deliveryNote == null)
                return null;
            return new DeliveryNoteApi
            {
                Id = deliveryNote.Id,
                Number = deliveryNote.Number,
                DeliveryDate = deliveryNote.DeliveryDate,
                ProviderId = deliveryNote.ProviderId,
            };
        }
        public static explicit operator DeliveryNote(DeliveryNoteApi deliveryNote)
        {
            if (deliveryNote == null)
                return null;
            return new DeliveryNote
            {
                Id = deliveryNote.Id,
                Number = deliveryNote.Number,
                DeliveryDate = deliveryNote.DeliveryDate,
                ProviderId = deliveryNote.ProviderId,
            };
        }
    }
}
