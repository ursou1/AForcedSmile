using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForcedSmile.db
{
    public partial class Client
    {
        public static explicit operator ClientApi(Client client)
        {
            if (client == null)
                return null;
            return new ClientApi
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                FatherName = client.FatherName,
                Telephone = client.Telephone,
                Address = client.Address,
                Email = client.Email
            };
        }
        public static explicit operator Client(ClientApi client)
        {
            if (client == null)
                return null;
            return new Client
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                FatherName = client.FatherName,
                Telephone = client.Telephone,
                Address = client.Address,
                Email = client.Email
            };
        }
    }
}
