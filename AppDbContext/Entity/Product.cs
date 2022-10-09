using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Product
	{	
		[Key]
		public string Name { get; set; }
		public double Rating { get; set; }
		public double Price { get; set; }
		public string ImgPath { get; set; }
		public string? Note { get; set; }
	}
}
