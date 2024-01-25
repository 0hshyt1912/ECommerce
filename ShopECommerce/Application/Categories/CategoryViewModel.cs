﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories
{
	public class CategoryViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int ProductCount { get; set; }
	}
}
