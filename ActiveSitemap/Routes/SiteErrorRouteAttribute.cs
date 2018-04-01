using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes {

	public class SiteErrorRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "error";

		public string BuildUrl() { return AppMap.MakeAbsolute("/error"); }

		public RedirectResult CreateRedirect() { return MakeRedirect("/error"); }

	}

}
