using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.ViewComponents.LayoutComponents
{
	public class _LayoutHeaderComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
