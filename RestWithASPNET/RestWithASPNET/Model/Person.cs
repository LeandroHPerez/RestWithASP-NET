﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public long LastName { get; set; }
        public long Address { get; set; }
        public long Gender { get; set; }

    }
}
