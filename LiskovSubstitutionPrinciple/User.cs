using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiskovSubstitutionPrinciple;

namespace LiskovSubstitutionPrinciple
{
    public abstract  class User
    {
        public abstract bool CanChangePermissions();
    }

    public class Admin : User
    {
        public override bool CanChangePermissions() => true;
    }

    public class GuestAdmin : Admin
    {
        public override bool CanChangePermissions() => false;
    }
}

public class UserManager
{
    public void AddPermission(User user, string permission)
    {
        //We expect that all the users will be able to check for the permission
        if(user.CanChangePermissions())
        {
            // Add permission logic
            Console.WriteLine($"Permission {permission} added to user.");
        }
        else
        {
            Console.WriteLine($"User does not have permission to change permissions.");
        }
    }
}