using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.DbModels
{
    public partial class User
    {
        public User()
        {
            BookAndReaders = new HashSet<BookAndReader>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public int RoleId { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<BookAndReader> BookAndReaders { get; set; }
    }
}
