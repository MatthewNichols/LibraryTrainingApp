using System.Collections.Generic;

namespace Library.ApiResources
{
	public class BookResource
	{
		public BookResource()
		{
			AuthorIds = new List<int>();
			Authors = new List<AuthorResource>();
		}

		public int Id { get; set; }

		public string Title { get; set; }

		public string ISBN { get; set; }

		public ICollection<int> AuthorIds { get; set; }
		public ICollection<AuthorResource> Authors { get; set; }
	}
}