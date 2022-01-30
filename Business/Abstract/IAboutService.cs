﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About about);

        IResult Delete(About about);
        IDataResult<List<About>> GetAll();

    }
}