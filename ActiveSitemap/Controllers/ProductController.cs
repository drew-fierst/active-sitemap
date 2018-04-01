using System.Collections.Generic;
using System.Linq;
using ActiveSitemap.Models;
using ActiveSitemap.Routes.ProductRoutes;
using Microsoft.AspNetCore.Mvc;

namespace ActiveSitemap.Controllers {

	public class ProductController : Controller {

		private static readonly IList<ProductCategory> Categories = new List<ProductCategory> {
			new ProductCategory {CategoryId = 1, CategoryName = "Hats", UrlSlug = "hats"},
			new ProductCategory {CategoryId = 2, CategoryName = "Shoes", UrlSlug = "shoes"},
			new ProductCategory {CategoryId = 3, CategoryName = "Outdoor Gear", UrlSlug = "outdoor-gear"},
			new ProductCategory {CategoryId = 4, CategoryName = "Sports Wear", UrlSlug = "sports-wear"},
		};

		private static readonly IList<Product> Products = new List<Product> {
			new Product { ProductId = 1, ProductName = "Product 1", Description = "Description of product 1", Price = 24.95M },
			new Product { ProductId = 2, ProductName = "Product 2", Description = "Description of product 2", Price = 19.95M },
			new Product { ProductId = 3, ProductName = "Product 3", Description = "Description of product 3", Price = 22.95M },
			new Product { ProductId = 4, ProductName = "Product 4", Description = "Description of product 4", Price = 17.95M },
			new Product { ProductId = 5, ProductName = "Product 5", Description = "Description of product 5", Price = 12.95M },
		};

		[ProductListRoute]
		public IActionResult Index() {
			ViewBag.Message = "Display of list of products";

			return View(Categories);
		}

		[ProductsInCategoryRoute]
		public IActionResult CategoryProducts(string slug) {
			if (string.IsNullOrEmpty(slug)) return BadRequest();

			var cat = Categories.FirstOrDefault(c => c.UrlSlug == slug);
			if (cat == null) return NotFound();

			ViewBag.Message = $"Display all products in the {cat.CategoryName} category";

			return View(Products);
		}

		[ProductDetailsRoute]
		public IActionResult ProductDetails(int? id) {
			if (!id.HasValue) return BadRequest();

			var model = Products.FirstOrDefault(p => p.ProductId == id.Value);
			if (model == null) return NotFound();

			ViewBag.Message = $"Display details of product whose id = {id}";
			return View(model);
		}


	}

}