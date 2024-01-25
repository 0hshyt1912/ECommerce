using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractrions
{
	public interface IRepository<TEntity, TKey> where TEntity : class
	{
		IQueryable<TEntity> FindAll();
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task<TEntity> FindById(TKey id);
	}
}
