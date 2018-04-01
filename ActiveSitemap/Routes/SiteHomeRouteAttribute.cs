using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes {

	public class SiteHomeRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "";

		public string BuildUrl() { return AppMap.MakeAbsolute("/"); }

		public RedirectResult CreateRedirect() { return MakeRedirect("/"); }


	}

}
