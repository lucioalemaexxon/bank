using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Auth.Domain.Users
{
    public class User
    {
        [Key]
        public string UserName { get; private set; }
        [Required]
        public string Password { get; private set; }
        public string Avatar { get; private set; }

        public User(string userName, string password, string avatar)
        {
            UserName = userName;
            Password = !string.IsNullOrEmpty(password) ? password : throw new ArgumentNullException();
            Avatar = avatar;
        }

        public bool PasswordMatches(string passwordToTest) => Password == passwordToTest;
    }
}
