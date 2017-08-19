using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interfaces;

namespace Library.Data.Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly LibraryContext _libraryContext;

		public AuthorRepository(LibraryContext libraryContext)
		{
			_libraryContext = libraryContext;
		}

		public Author GetById(int id)
		{
			return _libraryContext.Authors.FirstOrDefault(b => b.Id == id);
		}

		public IEnumerable<Author> GetAllForIds(int[] ids)
		{
			return _libraryContext.Authors.Where(a => ids.Contains(a.Id));
		}

		public Task<Author> Add(Author entity)
		{
			throw new NotImplementedException();
		}
	}
}
