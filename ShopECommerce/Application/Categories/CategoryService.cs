﻿using Application.Products;
using Domain.Abstractrions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories
{
	public interface ICategoryService
	{
		List<CategoryViewModel> GetCategories();
	}
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category, Guid> _categoryRepository;
		private readonly IRepository<Product, Guid> _productRepository;

		public CategoryService(
			IRepository<Category, Guid> categoryRepository,
			IRepository<Product, Guid> productRepository)
		{
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
		}

		public List<CategoryViewModel> GetCategories()
		{
			var categoryViewModels = new List<CategoryViewModel>();
			var productViewModels = new List<ProductViewModel>();
			var products = _productRepository.FindAll();
			var categories = _categoryRepository.FindAll();
			var result = (from p in products
						  join c in categories
						  on p.CategoryId equals c.Id
						  select new ProductViewModel
						  {
							  ProductId = p.Id,
							  ProductName = p.Name,
							  Price = p.Price,
							  DiscountPrice = p.DiscountPrice,
							  CategoryName = c.Name,
							  CategoryId = c.Id,
						  }).AsEnumerable();
			var groups = result.GroupBy(s => s.CategoryId);
			foreach (var item in groups)
			{

				var productsInGroup = item.ToList();

				var categoryViewModel = new CategoryViewModel
				{
					Id = item.Key,
					Name = productsInGroup.FirstOrDefault().CategoryName,
					ProductCount = productsInGroup.Count,
				};
				categoryViewModels.Add(categoryViewModel);
			}
			return categoryViewModels;
		}
	}
}
