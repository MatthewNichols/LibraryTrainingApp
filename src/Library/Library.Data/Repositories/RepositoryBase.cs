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

		public T GetById(int id)
		{
			return DbSet.FirstOrDefault(t => t.Id == id);
		}

		public void Save(T entity)
		{
			DbSet.Add(entity);
			LibraryDbContext.SaveChanges();
		}
	}
}
