using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
