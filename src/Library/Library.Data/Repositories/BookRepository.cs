using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Models;

namespace Library.Data.Repositories
{
	public class BookRepository: RepositoryBase<Book>
	{
		public BookRepository(LibraryDbContext libraryDbContext)
			: base(libraryDbContext, libraryDbContext.Books)
		{
			
		}
	}
}
