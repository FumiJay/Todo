using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.MyModels;

namespace Todo.Services
{
    public interface IAuthentication //Authentication 認證(who are you)
    {
        UserModel GetUser();
        Task<bool> DoLogin(UserModel user);
        Task DoLogout();
        Task<bool> IsLogin();
    }
}
