using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
	public interface IGenericRepository<T> where T: IHasId
	{
		T GetById(int id);
		IEnumerable<T> GetAllForIds(int[] ids);
		void Save(T entity);
	}
}
