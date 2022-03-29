using AForcedSmile.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryNoteViewController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public DeliveryNoteViewController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        //[HttpGet]
        //public IEnumerable<DeliveryNoteApi> Get()
        //{
        //    return dbContext.DeliveryNotes.ToList().Select(s =>
        //    {
        //      return (DeliveryNoteApi)s;
        //    });
        //    return dbContext.DeliveryNotes.ToList().Select(s =>
        //    {
        //        return CreateDeliveryNoteApi((DeliveryNoteApi)s);
        //    });
        //}

        private DeliveryNoteView CreateDeliveryNoteApi(DeliveryNote deliveryNote)
        {
            var result = new DeliveryNoteView { DeliveryNote = (DeliveryNoteApi)deliveryNote };
            result.Provider = (ProviderApi)dbContext.Providers.First(s => s.Id == deliveryNote.ProviderId);
            return result;
        }
    }
}
