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
	public class BookAndReaderDal : BaseDal<DefaultDbContext, BookAndReader, Entities.BookAndReader, int, BookAndReaderSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BookAndReaderDal()
		{
		}

		protected internal BookAndReaderDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.BookAndReader entity, BookAndReader dbObject, bool exists)
		{
			dbObject.IdBook = entity.IdBook;
			dbObject.IdReader = entity.IdReader;
			return Task.CompletedTask;
		}

		protected override Task<IQueryable<BookAndReader>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<BookAndReader> dbObjects, BookAndReaderSearchParams searchParams)
		{
			dbObjects = dbObjects.OrderBy(item => item.Id);
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.BookAndReader>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<BookAndReader> dbObjects, object convertParams, bool isFull)
		{
			dbObjects = dbObjects.Include(item => item.IdBookNavigation);
			dbObjects = dbObjects.Include(item => item.IdReaderNavigation);
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<BookAndReader, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.BookAndReader, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.BookAndReader ConvertDbObjectToEntity(BookAndReader dbObject)
		{
			return dbObject == null ? null : new Entities.BookAndReader(dbObject.Id, dbObject.IdBook, dbObject.IdReader)
			{
				IdBookNavigation = BooksDal.ConvertDbObjectToEntity(dbObject.IdBookNavigation),
				IdReaderNavigation = UsersDal.ConvertDbObjectToEntity(dbObject.IdReaderNavigation),
			};
		}

		public async Task<Entities.BookAndReader> GetAsync(int id)
		{
			return (await GetAsync(item => item.Id == id)).FirstOrDefault();
		}
	}
}
