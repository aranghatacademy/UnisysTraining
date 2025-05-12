using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Model;

namespace SingleResponsibilityPrinciple
{
    public class UserManager
    {
        public EventHandler<NewRegistrationEvent> NewRegistrationEvent;

        public int Register(RegisterRequest request)
        {
            //Validation helper is responsible for validating the request
            if(!ValidationHelper.Validate(request))
            {
                throw new ValidationException("Invalid data");
            }

            var passwordHash = PasswordManager.HashPassword(request, request.Password);

            var userRepo = new UserRepository();
            var newUserId = userRepo.AddUser(request.Name, request.Email, passwordHash);

            if(newUserId > 0)
            {
                //Just inform everyone who is waiting to carry out post registration activities
                NewRegistrationEvent?
                        .Invoke(this,new 
                        NewRegistrationEvent { Email = request.Email
                        , Name = request.Name, UserId = newUserId });
            }

            return newUserId;
        }
    }

    public class NewRegistrationEvent : EventArgs
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
