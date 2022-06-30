using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Common.Enums;
using Common.Search;
using BooksAndReader = Entities.BookAndReader;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL
{
	public class BooksAndReadersBL
	{
		public async Task<int> AddOrUpdateAsync(BooksAndReader entity)
		{
			entity.Id = await new BookAndReaderDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BookAndReaderDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BookAndReaderSearchParams searchParams)
		{
			return new BookAndReaderDal().ExistsAsync(searchParams);
		}

		public Task<BooksAndReader> GetAsync(int id)
		{
			return new BookAndReaderDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BookAndReaderDal().DeleteAsync(id);
		}

		public Task<SearchResult<BooksAndReader>> GetAsync(BookAndReaderSearchParams searchParams)
		{
			return new BookAndReaderDal().GetAsync(searchParams);
		}

	}
}

