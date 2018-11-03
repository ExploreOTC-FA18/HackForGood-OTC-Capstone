using System;

namespace BorrowMyAngel.Model.Database
{
    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Salt { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
