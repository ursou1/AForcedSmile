﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class ClientApi: ApiBaseType
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
