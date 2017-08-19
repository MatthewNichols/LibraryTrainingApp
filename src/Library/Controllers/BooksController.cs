using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Library.ApiResources;
using Library.Data;
using Library.Data.Interfaces;
using Library.Infrastructure;

namespace Library.Controllers
{
    public class BooksController : ApiController
    {
	    private IBookRepository _bookRepository;

	    public BooksController()
	    {
		    _bookRepository = DependencyManagement.BookRepository;
	    }

        // GET: api/Books
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        public async Task<BookResource> Post([FromBody] BookResource bookData)
        {
	        var book = Mapper.Map<Book>(bookData);

	        await _bookRepository.Add(book);

	        var returnVal = Mapper.Map<BookResource>(book);

	        return returnVal;
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
