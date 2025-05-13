namespace LiskovSubstitutionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var userManager = new UserManager();
           // var admin = new Admin();
            var guestAdmin = new GuestAdmin();

            userManager.AddPermission(guestAdmin, "AdminPermission");*/

            var user = new AdminUser();
            var guestUser = new GuestAdminUser();
            var userManager = new UserManager<IPermissionService>();



            userManager.AddPermission(guestUser, "AdminPermission");
        }
    }
}
