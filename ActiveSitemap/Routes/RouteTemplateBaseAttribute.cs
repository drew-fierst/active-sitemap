using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ActiveSitemap.Routes {

	public interface ILogicalRouteTemplateProvider : IRouteTemplateProvider {

	}

	public abstract class RouteTemplateBaseAttribute : Attribute, ILogicalRouteTemplateProvider {

		public abstract string Template { get; }
		public virtual int? Order { get; set; }
		public virtual string Name { get; set; }

		protected static RedirectResult MakeRedirect(string url) { return new RedirectResult(url); }

	}

}
