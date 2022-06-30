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
	public class BooksController : Controller
	{
		[Authorize]
		public async Task<IActionResult> Index(BooksFilterModel filterModel, int page = 1)
		{
			const int objectsPerPage = 10;
			var types = typeof(TypesBook).GetEnumValues().Cast<TypesBook>();
			var searchResult = await new BooksBL().GetAsync(new BooksSearchParams
			{
				Name = filterModel.Name,
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
				TypeBook = filterModel.TypeBook,
			});
			var viewModel = new SearchResultViewModel<BookModel, BooksFilterModel>(
				BookModel.FromEntitiesList(searchResult.Objects), filterModel,
				searchResult.Total, searchResult.RequestedStartIndex, searchResult.RequestedObjectsCount, 5);
			return View(viewModel);
		}

		[Authorize]
		public async Task<IActionResult> Update(int? id)
		{
			var model = new BookModel();
			if (id != null)
			{
				model = BookModel.FromEntity(await new BooksBL().GetAsync(id.Value));
				if (model == null)
				{
					return NotFound();
				}
			}
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = nameof(UserRole.Admin))]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(BookModel model)
		{
			var oldUser = BookModel.FromEntity(await new BooksBL().GetAsync(model.Id));
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new BooksBL().AddOrUpdateAsync(BookModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}
	}
}
