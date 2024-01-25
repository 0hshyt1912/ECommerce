﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public class GenericData<TViewModel> where TViewModel : class
	{
		public int Count { get; set; }
		public List<TViewModel> Data { get; set; }
	}
}
