using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class BookAndReaderSearchParams : BaseSearchParams
	{
		public string SearchQuery { get; set; }

		public BookAndReaderSearchParams(string searchQuery = null, int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
			SearchQuery = searchQuery;
		}
	}
}
