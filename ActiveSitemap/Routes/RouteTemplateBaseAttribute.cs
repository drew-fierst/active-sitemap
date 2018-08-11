using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ActiveSitemap.Routes {

	public interface ILogicalRouteTemplateProvider : IRouteTemplateProvider {

		ILogicalRouteTemplateProvider AddChild(ILogicalRouteTemplateProvider child);

		ILogicalRouteTemplateProvider SetParent(ILogicalRouteTemplateProvider parent);

		IEnumerable<ILogicalRouteTemplateProvider> Children { get; }
	}

	public abstract class RouteTemplateBaseAttribute : Attribute, ILogicalRouteTemplateProvider {

		public abstract string Template { get; }
		public virtual int? Order { get; set; }
		public virtual string Name { get; set; }

		protected static RedirectResult MakeRedirect(string url) { return new RedirectResult(url); }

		private readonly IList<ILogicalRouteTemplateProvider> children = new List<ILogicalRouteTemplateProvider>();

		public IEnumerable<ILogicalRouteTemplateProvider> Children => children.ToImmutableArray();

		public ILogicalRouteTemplateProvider AddChild(ILogicalRouteTemplateProvider child) {
			children.Add(child);
			child.SetParent(this);
			return this;
		}

		private ILogicalRouteTemplateProvider parent;
		public ILogicalRouteTemplateProvider SetParent(ILogicalRouteTemplateProvider newParent) {
			parent = newParent;
			return this;
		}

	}

}
