using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes {

	public class AboutUsRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "about-us";

		public string BuildUrl() { return AppMap.MakeAbsolute("/about-us"); }

		public RedirectResult CreateRedirect() { return MakeRedirect("/about-us"); }

	}

}
