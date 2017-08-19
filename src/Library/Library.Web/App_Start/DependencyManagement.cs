using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Data.Repositories;
using Library.Web.ApiResources;

namespace Library.Web.App_Start
{
	public class DependencyManagement
	{
		private static readonly LibraryDbContext LibraryDbContext = new LibraryDbContext();
		public static IAuthorRepository AuthorRepository = new AuthorRepository(LibraryDbContext);
		public static IBookRepository BookRepository = new BookRepository(LibraryDbContext);

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
				config.CreateMap<Author, AuthorResource>();


			});
		}
	}
}