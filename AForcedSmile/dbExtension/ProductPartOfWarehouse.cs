using ModelsApi;

namespace AForcedSmile.db
{
    public partial class ProductPartOfWarehouse
    {
        public static explicit operator ProductPartOfWarehouseApi(ProductPartOfWarehouse productPartOfWarehouse)
        {
            if (productPartOfWarehouse == null)
                return null;
            return new ProductPartOfWarehouseApi
            {
                Id = productPartOfWarehouse.Id,
                ProductId = productPartOfWarehouse.ProductId,
                PartOfWarehouseId = productPartOfWarehouse.PartOfWarehouseId,
                ProductCount = productPartOfWarehouse.ProductCount
            };
        }
        public static explicit operator ProductPartOfWarehouse(ProductPartOfWarehouseApi productPartOfWarehouse)
        {
            if (productPartOfWarehouse == null)
                return null;
            return new ProductPartOfWarehouse
            {
                Id = productPartOfWarehouse.Id,
                ProductId = productPartOfWarehouse.ProductId,
                PartOfWarehouseId = productPartOfWarehouse.PartOfWarehouseId,
                ProductCount = productPartOfWarehouse.ProductCount
            };
        }
    }
}
