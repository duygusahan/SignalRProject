﻿using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        public int CategoryCount();

        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}
