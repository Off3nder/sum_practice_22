using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class BooksDal : BaseDal<DefaultDbContext, Book, Entities.Book, int, BooksSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BooksDal()
		{
		}

		protected internal BooksDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Book entity, Book dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.AuthorFirstName = entity.AuthorFirstName;
			dbObject.AuthorSecondName = entity.AuthorSecondName;
			dbObject.AuthorThirdName = entity.AuthorThirdName;
			dbObject.DescriptionBook = entity.DescriptionBook;
			dbObject.TypeBook = (int)entity.TypeBook;
			return Task.CompletedTask;
		}

		protected override Task<IQueryable<Book>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Book> dbObjects, BooksSearchParams searchParams)
		{
			if (searchParams.TypeBook != null)
			{
				var typeArray = searchParams.TypeBook.Cast<int>().ToArray();
				dbObjects = dbObjects.Where(item => typeArray.Contains(item.TypeBook));
			}
			if (!string.IsNullOrEmpty(searchParams.Name))
			{
				dbObjects = dbObjects.Where(item => item.Name.Contains(searchParams.Name));
			}
			dbObjects = dbObjects.OrderBy(item => item.Name);
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Book>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Book> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Book, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Book, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Book ConvertDbObjectToEntity(Book dbObject)
		{
			return dbObject == null ? null : new Entities.Book(dbObject.Id, dbObject.Name, dbObject.AuthorFirstName,
				dbObject.AuthorSecondName, dbObject.AuthorThirdName, dbObject.DescriptionBook, (TypesBook)dbObject.TypeBook);
		}

		public async Task<Entities.Book> GetAsync(int id)
		{
			return (await GetAsync(item => item.Id == id)).FirstOrDefault();
		}
	}
}
