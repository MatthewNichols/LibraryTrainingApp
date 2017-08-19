using Library.Data.Models;

namespace Library.Data.Repositories
{
	public class AuthorsRepository: RepositoryBase<Author>
	{
		public AuthorsRepository(LibraryDbContext libraryDbContext)
			: base(libraryDbContext, libraryDbContext.Authors)
		{
			
		}
	}
}