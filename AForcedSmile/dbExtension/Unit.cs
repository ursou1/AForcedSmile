using ModelsApi;

namespace AForcedSmile.db
{
    public partial class Unit
    {
        public static explicit operator UnitApi(Unit unit)
        {
            if (unit == null)
                return null;
            return new UnitApi
            {
                Id = unit.Id,
                Title = unit.Title
            };
        }
        public static explicit operator Unit(UnitApi unit)
        {
            if (unit == null)
                return null;
            return new Unit
            {
                Id = unit.Id,
                Title = unit.Title
            };
        }
    }
}
