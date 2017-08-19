using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interfaces;

namespace Library.Data.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly LibraryContext _libraryContext;

		public BookRepository(LibraryContext libraryContext)
		{
			_libraryContext = libraryContext;
		}

		public Book GetById(int id)
		{
			return _libraryContext.Books.FirstOrDefault(b => b.Id == id);
		}

		public IEnumerable<Book> GetAllForIds(int[] ids)
		{
			throw new NotImplementedException();
		}

		public async Task<Book> Add(Book entity)
		{
			_libraryContext.Books.Add(entity);
			await _libraryContext.SaveChangesAsync();
			return entity;
		}
	}
}
