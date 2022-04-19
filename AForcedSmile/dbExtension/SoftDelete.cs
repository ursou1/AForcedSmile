using ModelsApi;

namespace AForcedSmile.db
{
    public partial class SoftDelete
    {
        public static explicit operator SoftDeleteApi(SoftDelete softDelete)
        {
            if (softDelete == null)
                return null;
            return new SoftDeleteApi
            {
                Id = softDelete.Id,
                Deleted = softDelete.Deleted,
                DeleteDate = softDelete.DeleteDate
            };
        }
        public static explicit operator SoftDelete(SoftDeleteApi softDelete)
        {
            if (softDelete == null)
                return null;
            return new SoftDelete
            {
                Id = softDelete.Id,
                Deleted = softDelete.Deleted,
                DeleteDate = softDelete.DeleteDate
            };
        }
    }
}
