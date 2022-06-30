using Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Areas.Admin.Models.ViewModels.FilterModels
{
	public class BooksFilterModel : BaseFilterModel
	{
		[Display(Name = "Тип книги")]
		public IEnumerable<TypesBook> TypeBook { get; set; }
		[Display(Name = "Имя книги")]
		public string Name { get; set; }

	}
}
