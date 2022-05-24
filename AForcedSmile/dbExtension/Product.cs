using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.db
{
    public partial class Product
    {
        public static explicit operator ProductApi(Product product)
        {
            if (product == null)
                return null;
            return new ProductApi
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                UnitId = product.UnitId,
                DeliveryNoteId = product.DeliveryNoteId,
                DepartNoteId = product.DepartNoteId,
                ProductTypeId = product.ProductTypeId,
                Image = product.Image,
                Description = product.Description,
                SoftDeleteId = product.SoftDeleteId
            };
        }
        public static explicit operator Product(ProductApi product)
        {
            if (product == null)
                return null;
            return new Product
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                UnitId = product.UnitId,
                DeliveryNoteId = product.DeliveryNoteId,
                DepartNoteId = product.DepartNoteId,
                ProductTypeId = product.ProductTypeId,
                Image = product.Image,
                Description = product.Description,
                SoftDeleteId = product.SoftDeleteId
            };
        }
    }
}
