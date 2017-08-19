using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
	public interface IBookRepository: IGenericRepository<Book>
	{
	}
}
