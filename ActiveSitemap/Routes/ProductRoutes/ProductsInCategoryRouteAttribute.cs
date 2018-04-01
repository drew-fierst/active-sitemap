using ActiveSitemap.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes.ProductRoutes {

	public class ProductsInCategoryRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "products/category/{slug}";

		public string BuildUrl(ProductCategory cat) { return BuildUrl(cat.UrlSlug); }
		public string BuildUrl(string urlSlug) { return AppMap.MakeAbsolute($"/products/category/{urlSlug}"); }

		public RedirectResult CreateRedirect(ProductCategory cat) { return CreateRedirect(cat.UrlSlug); }
		public RedirectResult CreateRedirect(string urlSlug) { return MakeRedirect($"/products/category/{urlSlug}"); }

	}

}
