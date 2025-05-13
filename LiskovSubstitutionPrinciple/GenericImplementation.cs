using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public interface IPermissionService
    {
        bool CanChangePermissions();
    }


    public class AdminUser : IPermissionService
    {
        public bool CanChangePermissions() => true;
    }

    public class GuestAdminUser : IPermissionService
    {
        public bool CanChangePermissions() => false;
    }

    public class UserManager<T> where T : IPermissionService
    {
        public void AddPermission(T user, string permission)
        {
            // Check if the user can change permissions
            if (user.CanChangePermissions())
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
}
