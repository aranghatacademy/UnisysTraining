

using CredentialManagement;

namespace ToDoApi.Services
{
   
    public interface IUserService
    {
        string Login(string username, string password);
    }

    public class UserService : IUserService
    {

        public UserService()
        {
            var cred = new Credential
            {
                Target = "MyPasswordService",
                Username = "admin",
                Password = "pass1234$$",
                Type = CredentialType.Generic,
                PersistanceType = PersistanceType.LocalComputer,


            };

            cred.Save();
        }

        public string Login(string username, string password)
        {
            var cred = new Credential
            {
                Target = "MyPasswordService"
            };

            if (cred.Load())
            {
                var isAuthSuccess = cred.Username == username && cred.Password == password;

                //Create a JWT Token
                return "TestToken";
            }

            throw new UnauthorizedAccessException();

        }
    }
}
