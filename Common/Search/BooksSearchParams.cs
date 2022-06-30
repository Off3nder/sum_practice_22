using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class BooksSearchParams : BaseSearchParams
	{
		public IEnumerable<TypesBook> TypeBook { get; set; }
		public string Name { get; set; }

		public BooksSearchParams(IEnumerable<TypesBook> type = null, string searchQuery = null, int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
			TypeBook = type;
			Name = searchQuery;
		}
	}
}
