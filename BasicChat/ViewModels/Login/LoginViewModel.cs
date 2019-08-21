using System;
using System.Collections.Generic;
using System.Text;
using BasicChat.Infraestructure;
using BasicChat.Service;
using BasicChat.Views.Login;
using Xamarin.Forms;

namespace BasicChat.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private readonly AuthService _authService;
      
        public LoginViewModel()
        {
            _authService= new AuthService();
            LoginCommand = new Command(OnLoginCommandExecuted, OnLoginCommandCanExecuted);
            SignupCommand = new Command(OnSignupCommandExecuted);
            Username = string.Empty;
            Password = string.Empty;
        }

        public string Username {
            get => _username;
            set {
                if (SetProperty(ref _username, value))
                    LoginCommand.ChangeCanExecute();
            }
        }

        public string Password {
            get => _password;
            set {
                if (SetProperty(ref _password, value))
                    LoginCommand.ChangeCanExecute();
            }
        }

        public Command LoginCommand { get; set; }
        public Command SignupCommand { get; set; }

        public async  void OnLoginCommandExecuted()
        {
            var result = await _authService.Login(Username,Password);
            if (result.ResponseType != EResponseType.Ok) return;
            if (result.Data != false) return;
            await Application.Current.MainPage.DisplayAlert("Error ", "REvisa tus datos", "ok");
            Password = string.Empty;
        }

        public bool OnLoginCommandCanExecuted()
        {
            return Username.Length > 3 && Password.Length > 3;
        }

        public async  void OnSignupCommandExecuted()
        {
              NavigationHelper.PushAsync(new Register());
        }
    }
}
