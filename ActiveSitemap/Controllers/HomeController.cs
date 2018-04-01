using System.Diagnostics;
using ActiveSitemap.Models;
using ActiveSitemap.Routes;
using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Controllers {

	public class HomeController : Controller {

		[SiteHomeRoute]
		public IActionResult Index() {
			return View();
		}

		[AboutUsRoute]
		public IActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[ContactUsRoute]
		public IActionResult Contact() {
			ViewBag.Message = "Use this form to contact us.";

			return View();
		}

		[ContactUsRoute]
		[HttpPost]
		public IActionResult Contact(ContactModel model) {
			if (ModelState.IsValid) {
				//process form submission here

				return AppMap.SiteHomeRoute.CreateRedirect();
			}

			return View(model);
		}

		[SiteErrorRoute]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
