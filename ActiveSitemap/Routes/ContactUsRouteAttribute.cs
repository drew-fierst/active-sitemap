using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes {

	public class ContactUsRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "contact-us";

		public string BuildUrl() { return AppMap.MakeAbsolute("/contact-us"); }

		public RedirectResult CreateRedirect() { return MakeRedirect("/contact-us"); }

	}

}
