using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.ApiResources
{
	public class BookResource
	{
		public int Id { get; set; }		
		public string Title { get; set; }
		public string ISBN { get; set; }
		public ICollection<AuthorResource> Authors { get; set; }
		public int[] AuthorIds { get; set; }
	}
}