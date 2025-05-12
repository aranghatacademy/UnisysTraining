using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class UserRepository
    {
        public UserRepository() { }

        public int AddUser(string name, string email, string passwordHash)
        {
            //Responsibility 3 - Database
            Console.WriteLine($"Adding user with {name}, {email}, {passwordHash}");
            return 1;
        }
    }
}
