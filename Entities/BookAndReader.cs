using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class BookAndReader
	{
		public int Id { get; set; }
		public int IdBook { get; set; }
		public int IdReader { get; set; }

		public Book IdBookNavigation { get; set; }
		public User IdReaderNavigation { get; set; }

		public BookAndReader(int id, int bookId, int readerId)
		{
			Id = id;
			IdBook = bookId;
			IdReader = readerId;
		}
	}
}
