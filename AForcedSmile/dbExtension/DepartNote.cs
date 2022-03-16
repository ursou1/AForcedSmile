using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.db
{
    public partial class DepartNote
    {
        public static explicit operator DepartNoteApi(DepartNote departNote)
        {
            if (departNote == null)
                return null;
            return new DepartNoteApi
            {
                Id = departNote.Id,
                Number = departNote.Number,
                DepartDate = departNote.DepartDate,
                ClientId = departNote.ClientId,
            };
        }
        public static explicit operator DepartNote(DepartNoteApi departNote)
        {
            if (departNote == null)
                return null;
            return new DepartNote
            {
                Id = departNote.Id,
                Number = departNote.Number,
                DepartDate = departNote.DepartDate,
                ClientId = departNote.ClientId,
            };
        }
    }
}
