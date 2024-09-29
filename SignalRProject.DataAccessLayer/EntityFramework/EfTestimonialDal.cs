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
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimionialDal
    {
        public EfTestimonialDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusToFalseTestimonials(int id)
        {
            using var context = new SignalRContext();
            var value = context.Testimonials.Find(id);
            value.Status=false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrueTestimonials(int id)
        {
            using var context = new SignalRContext();
            var value = context.Testimonials.Find(id);
            value.Status=true;
            context.SaveChanges();
        }

        public List<Testimonial> GetTestimonialsByStatusTrue()
        {
            using var context = new SignalRContext();
            var value=context.Testimonials.Where(x=>x.Status==true).ToList();
            return value;
        }
    }
}
