using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
