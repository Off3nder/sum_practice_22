using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.DbModels
{
    public partial class BookAndReader
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public int IdReader { get; set; }

        public virtual Book IdBookNavigation { get; set; }
        public virtual User IdReaderNavigation { get; set; }
    }
}
