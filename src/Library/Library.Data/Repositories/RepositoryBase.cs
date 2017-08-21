using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interfaces;

namespace Library.Data.Repositories
{
	public abstract class RepositoryBase<T> : IGenericRepository<T> where T : class, IHasId
	{
		protected readonly LibraryDbContext LibraryDbContext;
		protected readonly DbSet<T> DbSet;

		protected RepositoryBase(LibraryDbContext libraryDbContext, DbSet<T> dbSet)
		{
			this.LibraryDbContext = libraryDbContext;
			this.DbSet = dbSet;
		}

		public IEnumerable<T> GetAllForIds(int[] ids)
		{
			return DbSet.Where(t => ids.Contains(t.Id));
		}

		public IEnumerable<T> GetAll()
		{
			return DbSet;
		}

		public T GetById(int id)
		{
			return DbSet.FirstOrDefault(t => t.Id == id);
		}

		public T Save(T entity)
		{
			if (entity.Id == 0)
			{
				DbSet.Add(entity);
			}
			else
			{
				var entityToUpdate = GetById(entity.Id);
				LibraryDbContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
			}
			
			LibraryDbContext.SaveChanges();
			return entity;
		}

		public T Delete(int id)
		{
			var entity = GetById(id);
			if (entity == null)
			{
				throw new ArgumentException(@"No entity with that Id", nameof(id));
			}

			DbSet.Remove(entity);
			LibraryDbContext.SaveChanges();
			return entity;
		}
	}
}
