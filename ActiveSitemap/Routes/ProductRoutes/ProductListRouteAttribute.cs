using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes.ProductRoutes {

	public class ProductListRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "products";

		public string BuildUrl() { return AppMap.MakeAbsolute("/products"); }

		public RedirectResult CreateRedirect() { return MakeRedirect("/products"); }

	}

}
