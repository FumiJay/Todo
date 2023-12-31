﻿using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.BasePages;
using Todo.Models;
using Todo.MyModels;
using Todo.Services;

namespace Todo.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial  class AuthenticationViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _user = new UserModel();
        private bool _isLogin = false;
        //private readonly IAuthentication _authentication;
        private Authentication _authentication = new  Authentication();

        public AuthenticationViewModel()
        {
            //_authentication = authentication;
        }

        [RelayCommand]
        public async void GetUser()
        {
            _user = _authentication.GetUser();
            await Shell.Current.DisplayAlert("Please Login", "Login", "Ok");
        }

        [RelayCommand]
        public async void  IsLogin()
        {
            _isLogin = await _authentication.IsLogin();
        }

        [RelayCommand]
        public async void DoLogin()
        {
            User.IsBusy = true;

            var result = await _authentication.DoLogin(new UserModel
            {
                accountid = User.accountid,
                passwd = User.passwd,
            });

            if (result)
            {
                await Shell.Current.DisplayAlert("Status: Login Success", "Login Success", "Ok");
                await AppShell.Current.GoToAsync("///loading");
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Login Failed", "Login failed", "Ok");
            }
            
            User.IsBusy = false;
        }

        [RelayCommand]
        public async void DoLogout()
        {
            await _authentication.DoLogout();
            await Shell.Current.DisplayAlert("Status: Logout Success", "Logout Success", "Ok");
            await AppShell.Current.GoToAsync("///loading");
        }
    }
}
