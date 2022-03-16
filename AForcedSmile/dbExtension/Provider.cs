using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.db
{
    public partial class Provider
    {
        public static explicit operator ProviderApi(Provider provider)
        {
            if (provider == null)
                return null;
            return new ProviderApi
            {
                Id = provider.Id,
                Name = provider.Name,
                Telephone = provider.Telephone,
                Email = provider.Email
            };
        }
        public static explicit operator Provider(ProviderApi provider)
        {
            if (provider == null)
                return null;
            return new Provider
            {
                Id = provider.Id,
                Name = provider.Name,
                Telephone = provider.Telephone,
                Email = provider.Email
            };
        }
    }
}
