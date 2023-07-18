using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public class AuthService : IAuthService
    {
        private readonly String webApikey = "AIzaSyD2zBIjKv2qQ7DtSva5oRluEjs_x8uP6cI"; // Type your web api key
        private User _user;
        public bool isLogin = false;

        public UserModel GetUser()
        {
            UserModel model = new UserModel
            {
                name = _user.DisplayName,
                email = _user.Email,
                passwd = "",
            };
            return model;
        }

        public async Task<bool> IsLogin()
        {
            await Task.Delay(10);
            return isLogin;
        }

        public async Task<bool> LoginUserWithEmail(UserModel user)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApikey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(user.email, user.passwd);
                _user = auth.User;
                isLogin = true;
                return true;
            }
            catch
            {
                isLogin = false;
                return false;
            }
        }

        public async Task LogoutWithEmail() 
        {
            await Task.Delay(10);
            _user = new User();
            isLogin = false;
        }

        public async Task<bool> RegisterUserWithEmail(UserModel user)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApikey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(user.email, user.passwd);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
