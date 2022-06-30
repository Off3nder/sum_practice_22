using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string AuthorFirstName { get; set; }
		public string AuthorSecondName { get; set; }
		public string AuthorThirdName { get; set; }
		public string DescriptionBook { get; set; }
		public TypesBook TypeBook { get; set; }

		public Book(int id, string name, string aFirst, string aSecond, string aThird, string desc, TypesBook type)
		{
			Id = id;
			Name = name;
			AuthorFirstName = aFirst;
			AuthorSecondName = aSecond;
			AuthorThirdName = aThird;
			DescriptionBook = desc;
			TypeBook = type;
		}
	}
}
