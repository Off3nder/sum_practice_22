using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;
using Book = Entities.Book;

namespace UI.Areas.Admin.Models
{
	public class BookModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Название книги")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Имя автора ")]
		public string AuthorFirstName { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Фамилия автора ")]
		public string AuthorSecondName { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Отчество автора ")]
		public string AuthorThirdName { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Описание книги ")]
		public string DescriptionBook { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Тип ")]
		public TypesBook TypeBook { get; set; }

		public static BookModel FromEntity(Book obj)
		{
			return obj == null ? null : new BookModel
			{
				Id = obj.Id,
				Name = obj.Name,
			AuthorFirstName = obj.AuthorFirstName,
			AuthorSecondName = obj.AuthorSecondName,
			AuthorThirdName = obj.AuthorThirdName,
			DescriptionBook = obj.DescriptionBook,
			TypeBook = obj.TypeBook
		};
		}

		public static Book ToEntity(BookModel obj)
		{
			return obj == null ? null : new Book(obj.Id, obj.Name, obj.AuthorFirstName, obj.AuthorSecondName, obj.AuthorThirdName, obj.DescriptionBook, obj.TypeBook);
		}

		public static List<BookModel> FromEntitiesList(IEnumerable<Book> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Book> ToEntitiesList(IEnumerable<BookModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
