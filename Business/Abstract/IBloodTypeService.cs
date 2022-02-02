﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBloodTypeService
    {
        IDataResult<List<BloodType>> getAll();
    }
}