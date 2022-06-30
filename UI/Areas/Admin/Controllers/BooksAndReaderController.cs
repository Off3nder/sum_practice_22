using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL;
using Common.Enums;
using Common.Search;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Areas.Admin.Models;
using UI.Areas.Admin.Models.ViewModels;
using UI.Areas.Admin.Models.ViewModels.FilterModels;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BooksAndReaderController : Controller
	{
		//[Authorize]
		//public async Task<IActionResult> Index(BooksAndReaderFilterModel filterModel, int page = 1)
		//{
		//	const int objectsPerPage = 10;
		//	var types = typeof(TypesBook).GetEnumValues().Cast<TypesBook>();
		//	var searchResult = await new BooksAndReadersBL().GetAsync(new BookAndReaderSearchParams
		//	{
		//		Name = filterModel.Name,
		//		StartIndex = (page - 1) * objectsPerPage,
		//		ObjectsCount = objectsPerPage,
		//		TypeBook = filterModel.TypeBook,
		//	});
		//	var viewModel = new SearchResultViewModel<BookAndReaderModel, BooksAndReaderFilterModel>(
		//		BookAndReaderModel.FromEntitiesList(searchResult.Objects), filterModel,
		//		searchResult.Total, searchResult.RequestedStartIndex, searchResult.RequestedObjectsCount, 5);
		//	return View(viewModel);
		//}

		//[Authorize]
		//public async Task<IActionResult> Update(int? id)
		//{
		//	var model = new BookAndReaderModel();
		//	if (id != null)
		//	{
		//		model = BookAndReaderModel.FromEntity(await new BooksAndReadersBL().GetAsync(id.Value));
		//		if (model == null)
		//		{
		//			return NotFound();
		//		}
		//	}
		//	return View(model);
		//}

		//[HttpPost]
		//[Authorize(Roles = nameof(UserRole.Admin))]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Update(BookAndReaderModel model)
		//{
		//	var oldUser = BookAndReaderModel.FromEntity(await new BooksAndReadersBL().GetAsync(model.Id));
		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}
		//	await new BooksAndReadersBL().AddOrUpdateAsync(BookAndReaderModel.ToEntity(model));
		//	TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
		//	return RedirectToAction("Index");
		//}
	}
}
