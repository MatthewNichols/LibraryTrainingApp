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

	    public BookResource Post([FromBody]BookResource bookResource)
	    {
		    var book = Mapper.Map<Book>(bookResource);

		    var savedBook = _bookRepository.Save(book);

		    return Mapper.Map<BookResource>(savedBook);
	    }
    }
}
