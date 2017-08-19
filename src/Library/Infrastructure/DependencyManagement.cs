using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Library.ApiResources;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Repositories;

namespace Library.Infrastructure
{
	public class DependencyManagement
	{
		private static readonly LibraryContext _libraryContext = new LibraryContext();
		public static IAuthorRepository AuthorRepository = new AuthorRepository(_libraryContext);
		public static IBookRepository BookRepository = new BookRepository(_libraryContext);
		
		public static void SetupAppDependendencies()
		{
			SetupAutoMapper();
		}

		private static void SetupAutoMapper()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<BookResource, Book>()
					.AfterMap((src, dest) =>
					{
						var authors = AuthorRepository.GetAllForIds(src.AuthorIds.ToArray()).ToList();
						dest.Authors = authors;
					});

				config.CreateMap<Book, BookResource>();

			});
		}
	}
}