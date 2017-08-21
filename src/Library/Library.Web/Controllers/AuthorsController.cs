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
    public class AuthorsController : ApiController
    {
		private IAuthorRepository _authorRepository;

		public AuthorsController()
		{
			// How to handle Dependencies is beyond the scope of what I am working on here, so here is a simple 
			// encapsulation to keep my controlers from being too connected to contrete repositories. I only feel a little 
			// dirty doing it.
			_authorRepository = DependencyManagement.AuthorRepository;
		}

		public IEnumerable<AuthorResource> Get()
		{
			var authors = _authorRepository.GetAll();
			return Mapper.Map<IEnumerable<AuthorResource>>(authors);
		}

		public AuthorResource Get(int id)
		{
			var author = _authorRepository.GetById(id);
			return Mapper.Map<AuthorResource>(author);
		}

		public AuthorResource Post([FromBody]AuthorResource authorResource)
		{
			var author = Mapper.Map<Author>(authorResource);

			var savedAuthor = _authorRepository.Save(author);

			return Mapper.Map<AuthorResource>(savedAuthor);
		}

		public AuthorResource Put(int id, [FromBody]AuthorResource authorResource)
		{
			var author = Mapper.Map<Author>(authorResource);

			author.Id = id;
			var savedAuthor = _authorRepository.Save(author);

			return Mapper.Map<AuthorResource>(savedAuthor);
		}

		public void Delete(int id)
		{
			_authorRepository.Delete(id);
		}
	}
}
