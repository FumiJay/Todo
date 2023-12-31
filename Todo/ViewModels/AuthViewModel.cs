﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Models;
using Todo.Services;

namespace Todo.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class AuthViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _user = new UserModel();
        private readonly IAuthService _authService;
        private bool _isLogin = false;
        public AuthViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async void GetUser()
        {
            if (_isLogin)
            {
                _user = _authService.GetUser();
            }
            await Shell.Current.DisplayAlert("Please Login", "Login", "Ok");
        }

        [RelayCommand]
        public async void IsLogin()
        {
            _isLogin = await _authService.IsLogin();
        }

        [RelayCommand]
        public async void LogoutUser()
        {
            await _authService.LogoutWithEmail();
            _isLogin = await _authService.IsLogin();
            await Shell.Current.DisplayAlert("Status: Logout Success", "Logout Success", "Ok");
        }

        [RelayCommand]
        public async void LoginUserWithEmailAndPassword()
        {
            var result = await _authService.LoginUserWithEmail(new Models.UserModel
            {
                email = User.email,
                passwd = User.passwd,
            });

            if (result)
            {
                _isLogin = await _authService.IsLogin();
                await Shell.Current.DisplayAlert("Status: Login Success", "Login Success", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Login Failed", "Login failed", "Ok");
            }
        }

        [RelayCommand]
        public async void RegisterUserWithEmailAndPassword()
        {
            var result = await _authService.RegisterUserWithEmail(new Models.UserModel
            {
                email = User.email,
                passwd = User.passwd,
            });

            if (result)
            {
                await Shell.Current.DisplayAlert("Status: Register Success", "User registed", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Register Failed", "Something is failed", "Ok");
            }
        }
    }
}
