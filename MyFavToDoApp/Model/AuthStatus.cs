using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavToDoApp.Model
{
    public class AuthStatus
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
