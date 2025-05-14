using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthBAsics
{
    public  class WindowsAuthManager
    {
        List<string> users = new List<string>();

        public WindowsAuthManager()
        {
            // Add some dummy users for demonstration purposes
            users.Add("sreehariaranghat");
            users.Add("Administrator");
        }

        public bool Login()
        {
            var currentWindowsUser = WindowsIdentity.GetCurrent();
            var windowsPrincipal = new WindowsPrincipal(currentWindowsUser);

            // [Computer/Domain]\UserName
            var currentUserWithOutComputerName = currentWindowsUser.Name.Split('\\')[1];

       

            return users.Contains(currentUserWithOutComputerName) 
                            && windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
