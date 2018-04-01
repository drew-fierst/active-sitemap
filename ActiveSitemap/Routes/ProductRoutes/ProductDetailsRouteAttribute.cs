using ActiveSitemap.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Routes.ProductRoutes {

	public class ProductDetailsRouteAttribute : RouteTemplateBaseAttribute {

		public override string Template => "products/details/{id}";

		public string BuildUrl(Product product) { return BuildUrl(product.ProductId);}
		public string BuildUrl(int productId) { return AppMap.MakeAbsolute($"/products/details/{productId}"); }

		public RedirectResult CreateRedirect(Product product) { return CreateRedirect(product.ProductId); }
		public RedirectResult CreateRedirect(int productId) { return MakeRedirect($"/products/details/{productId}"); }

	}

}
