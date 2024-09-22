using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
    public class _DefaultBookComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
