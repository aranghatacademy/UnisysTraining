using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SingleResponsibilityPrinciple
{
    internal static class PasswordManager
    {
        public static string HashPassword<T>(T t,string password) where T : class
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException();

            // Hashing logic here
            var hashedPassword = new PasswordHasher<T>().HashPassword(t, password);
            return hashedPassword;
        }
    }
}
