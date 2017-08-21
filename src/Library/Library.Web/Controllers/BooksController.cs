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
	[RoutePrefix("/api/books")]
    public class BooksController : ApiController
    {
	    private IBookRepository _bookRepository;

	    public BooksController()
	    {
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

	    public BookResource Post([FromBody]BookResource bookResource)
	    {
		    var book = Mapper.Map<Book>(bookResource);

		    var savedBook = _bookRepository.Save(book);

		    return Mapper.Map<BookResource>(savedBook);
	    }

		public BookResource Put(int id, [FromBody]BookResource bookResource)
	    {
		    var book = Mapper.Map<Book>(bookResource);
			
		    var savedBook = _bookRepository.Save(book);

		    return Mapper.Map<BookResource>(savedBook);
	    }

		public void Delete(int id)
		{
			_bookRepository.Delete(id);
		}
    }
}
