using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Todo.Extensions;
using Todo.Helpers;
using Todo.Models;
using Todo.MyModels;

namespace Todo.Services
{
    public class Authentication : IAuthentication
    {
        public bool isLogin = false;
        public bool isBusy = true;
        public UserModel GetUser()
        {
            UserModel user = new UserModel
            {
               ApiToken =    GlobalData.ApiToken,
               LoginUserId = GlobalData.LoginUserId,
               LoginUser =   GlobalData.LoginUser,
            };

            return user;
        }

        public async Task<bool> IsLogin()
        {
            await Task.Delay(10);
            return isLogin;
        }

        public async Task<bool> DoLogin(UserModel user)
        {
            AESHelper aesHelper = new AESHelper();
            var pwd = aesHelper.Encrypt(user.passwd).Data;

            ReturnValueObject response = await App.helper.DoRequestAsync<ReturnValueObject>("1000", new UserModel { accountid = user.accountid, passwd = pwd }.Serialize());
            if (response.StatusCode == StatusCode.OK)
            {
                TUser u = response.GetResult<TUser>();
                GlobalData.ApiToken = u.token;
                GlobalData.LoginUser = u.user;
                GlobalData.LoginUserId = GlobalData.LoginUser.accountid;

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DoLogout() 
        {
            await Task.Delay(10);
            GlobalData.ApiToken = string.Empty;
            GlobalData.LoginUserId = string.Empty;
            GlobalData.LoginUser = new UserModel();
        }
    }

    public class TUser
    {
        public string token { get; set; }
        public UserModel user { get; set; }
    }
}
