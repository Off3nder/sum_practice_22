using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.DbModels
{
    public partial class Book
    {
        public Book()
        {
            BookAndReaders = new HashSet<BookAndReader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorSecondName { get; set; }
        public string AuthorThirdName { get; set; }
        public string DescriptionBook { get; set; }
        public int TypeBook { get; set; }

        public virtual ICollection<BookAndReader> BookAndReaders { get; set; }
    }
}
