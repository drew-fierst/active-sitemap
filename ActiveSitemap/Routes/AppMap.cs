using System;
using System.Collections.Generic;
using ActiveSitemap.CustomInfrastructure;
using ActiveSitemap.Routes.ProductRoutes;
using Microsoft.AspNetCore.Http;

namespace ActiveSitemap.Routes {

	//this class IS the Active Sitemap
	public class AppMap {

		private static IHttpContextAccessor _httpContextAccessor;

		private static bool _isConfigured;
		private static string _scheme = "";
		private static string _host = "";
		private static IList<ILogicalRouteTemplateProvider> _routes;

		#region Configuration Methods

		/// <summary>
		/// Configures the application routes object with current http scheme and host, for creating absolute URLs
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		public static void Configure(IHttpContextAccessor httpContextAccessor) {
			//we actually just need the scheme (http vs https) and host (www.example.com vs localhost:port)
			//but they do not yet exist at application startup and the IHttpContextAccessor does
			_httpContextAccessor = httpContextAccessor;
			ConfigureHierarchy();
		}

		private static void ConfigureHierarchy() {

			var siteRoot = (SiteHomeRoute)
				.AddChild(BuildProductHierarchy())
				.AddChild(AboutUsRoute)
				.AddChild(ContactUsRoute);

			_routes = new List<ILogicalRouteTemplateProvider> {
				siteRoot
			};
		}

		private static ILogicalRouteTemplateProvider BuildProductHierarchy() {

			var productRoot = ProductListRoute;

			productRoot.AddChild(ProductsInCategoryRoute);
			productRoot.AddChild(ProductDetailsRoute);

			return productRoot;
		}

		#endregion

		#region General Utilities

		public static string MakeAbsolute(string relativeUrl) {

			if (relativeUrl.StartsWith("http")) return relativeUrl;

			if (!_isConfigured) {
				if (_httpContextAccessor == null) {
					throw new ConfigurationException("AppRoutes must first be initialized with a call to Configure()");
				}

				var request = _httpContextAccessor.HttpContext.Request;
				_scheme = request.Scheme;
				_host = request.Host.Value;
				_isConfigured = true;
			}

			return new Uri(new Uri(_scheme + "://" + _host), relativeUrl).ToString();
		}

		#endregion

		#region Site Route Properties

		#region General Routes

		public static SiteHomeRouteAttribute SiteHomeRoute = new SiteHomeRouteAttribute();
		public static AboutUsRouteAttribute AboutUsRoute = new AboutUsRouteAttribute();
		public static ContactUsRouteAttribute ContactUsRoute = new ContactUsRouteAttribute();
		public static SiteErrorRouteAttribute SiteErrorRoute = new SiteErrorRouteAttribute();

		#endregion

		#region Product Routes

		public static ProductListRouteAttribute ProductListRoute = new ProductListRouteAttribute();
		public static ProductsInCategoryRouteAttribute ProductsInCategoryRoute = new ProductsInCategoryRouteAttribute();
		public static ProductDetailsRouteAttribute ProductDetailsRoute = new ProductDetailsRouteAttribute();

		#endregion


		#endregion



	}

}
