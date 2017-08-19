using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Data.Repositories
{
	public class AuthorRepository: RepositoryBase<Author>, IAuthorRepository
	{
		public AuthorRepository(LibraryDbContext libraryDbContext)
			: base(libraryDbContext, libraryDbContext.Authors)
		{
			
		}
	}
}