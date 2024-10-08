﻿using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TTotalOrderCount();

        int TActiveOrderCount();
        int TPassiveOrderCount();

        decimal TLastOrderPrice();

        decimal TTodayTotalPrice();
    }
}
