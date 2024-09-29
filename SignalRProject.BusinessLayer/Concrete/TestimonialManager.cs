using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DataAccessLayer.Abstract;
using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimionialDal _testimionialDal;

        public TestimonialManager(ITestimionialDal testimionialDal)
        {
            _testimionialDal = testimionialDal;
        }

        public void TChangeStatusToFalseTestimonials(int id)
        {
            _testimionialDal.ChangeStatusToFalseTestimonials(id);
        }

        public void TChangeStatusToTrueTestimonials(int id)
        {
            _testimionialDal.ChangeStatusToTrueTestimonials(id);
        }

        public void TDelete(int id)
        {
            _testimionialDal.Delete(id);
        }

        public Testimonial TGetById(int id)
        {
            return _testimionialDal.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimionialDal.GetListAll();
        }

        public List<Testimonial> TGetTestimonialsByStatusTrue()
        {
            return _testimionialDal.GetTestimonialsByStatusTrue();
        }

        public void TInsert(Testimonial entity)
        {
            _testimionialDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimionialDal.Update(entity);
        }
    }
}
