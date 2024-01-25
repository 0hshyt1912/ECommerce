using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;


namespace Domain.Entities
{
	public class BaseEntity
	{
		[Key]
		public Guid Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime CreatedDate { get; set; }
		public EntityStatus Status { get; set; }
	}
}
