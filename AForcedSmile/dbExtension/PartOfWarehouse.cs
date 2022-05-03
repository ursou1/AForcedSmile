using ModelsApi;

namespace AForcedSmile.db
{
    public partial class PartOfWarehouse
    {
        public static explicit operator PartOfWarehouseApi(PartOfWarehouse partOfWarehouse)
        {
            if (partOfWarehouse == null)
                return null;
            return new PartOfWarehouseApi
            {
                Id = partOfWarehouse.Id,
                Title = partOfWarehouse.Title
            };
        }
        public static explicit operator PartOfWarehouse(PartOfWarehouseApi partOfWarehouse)
        {
            if (partOfWarehouse == null)
                return null;
            return new PartOfWarehouse
            {
                Id = partOfWarehouse.Id,
                Title = partOfWarehouse.Title
            };
        }
    }
}
