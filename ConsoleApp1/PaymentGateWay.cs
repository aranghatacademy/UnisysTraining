using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PaymentGateWay
    {
        [PrincipalPermission(SecurityAction.Deny,Role = "Admin")]
        public void ChangeGatewayApi(string apiKey)
        {
            
        }
    }
}
