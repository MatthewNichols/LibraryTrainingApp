using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
	public interface IGenericRepository<T> where T : IHasId
	{
		Task<T> Add(T entity);
		T GetById(int id);
		IEnumerable<T> GetAllForIds(int[] ids);
		
	}

	public interface IBookRepository : IGenericRepository<Book>
	{
		
	}
	public interface IAuthorRepository : IGenericRepository<Author>
	{
		
	}
}
