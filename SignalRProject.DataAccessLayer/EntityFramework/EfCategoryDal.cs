using SignalRProject.DataAccessLayer.Abstract;
using SignalRProject.DataAccessLayer.Context;
using SignalRProject.DataAccessLayer.Repositories;
using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int CategoryCount()
        {
            using var context= new SignalRContext();
            return context.Categories.Count();
        }
    }
}
