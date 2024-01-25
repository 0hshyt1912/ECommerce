using Domain.Abstractrions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
	{
		private readonly ApplicationDbContext _context;
		public EfRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}

		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public IQueryable<TEntity> FindAll()
		{
			var result = _context.Set<TEntity>().AsQueryable();
			return result;
		}

		public async Task<TEntity> FindById(TKey id)
		{
			var result = await _context.Set<TEntity>().FindAsync(id);
			return result;
		}

		public void Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
		}
	}

}
