using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Web.ApiResources;
using Library.Web.App_Start;

namespace Library.Web.Controllers
{
	[RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
	    private IBookRepository _bookRepository;

	    public BooksController()
	    {
			// How to handle Dependencies is beyond the scope of what I am working on here, so here is a simple 
			// encapsulation to keep my controlers from being too connected to contrete repositories. I only feel a little 
			// dirty doing it.
			_bookRepository = DependencyManagement.BookRepository;
	    }

	    public IEnumerable<BookResource> Get()
	    {
		    var books = _bookRepository.GetAll();
		    return Mapper.Map<IEnumerable<BookResource>>(books);
	    }

	    public BookResource Get(int id)
	    {
		    var book = _bookRepository.GetById(id);
		    return Mapper.Map<BookResource>(book);
	    }

		[HttpGet]
		[Route("search/{searchString}")]
		public IEnumerable<BookResource> Search(string searchString)
		{
			var books = _bookRepository.Search(searchString);
			return Mapper.Map<IEnumerable<BookResource>>(books);
		}
		
	    public BookResource Post([FromBody]BookResource bookResource)
	    {
		    var book = Mapper.Map<Book>(bookResource);

		    var savedBook = _bookRepository.Save(book);

		    return Mapper.Map<BookResource>(savedBook);
	    }

		public BookResource Put(int id, [FromBody]BookResource bookResource)
	    {
		    var book = Mapper.Map<Book>(bookResource);

		    book.Id = id;	
		    var savedBook = _bookRepository.Save(book);

		    return Mapper.Map<BookResource>(savedBook);
	    }

		public void Delete(int id)
		{
			_bookRepository.Delete(id);
		}
    }
}
