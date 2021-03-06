﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Data.Repositories
{
	public class BookRepository: RepositoryBase<Book>, IBookRepository
	{
		public BookRepository(LibraryDbContext libraryDbContext)
			: base(libraryDbContext, libraryDbContext.Books)
		{
			
		}

		public IEnumerable<Book> Search(string searchString)
		{
			return DbSet.Where(b => b.Title.Contains(searchString));
		}
	}
}
