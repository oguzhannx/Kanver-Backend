﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    class City : IEntity
    {
        public int CityId { get; }
        public string CityName { get;}
    }
}
