using System.Net;
using BasicChat.Infraestructure;
using Xamarin.Forms;

namespace BasicChat.ViewModels.Login
{
    public class RegisterViewModel: BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _username;
        private string _password;

        public RegisterViewModel()
        {
             FirstName = string.Empty;
             LastName = string.Empty;
             Email = string.Empty;
             Username = string.Empty;
             Password = string.Empty;
             GoBackCommand = new Command(async () =>
             {
                 await NavigationHelper.Navigator.PopAsync();
             });
        }


        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName ,value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName ,value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email ,value);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username , value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password , value);
        }


        public Command GoBackCommand { get; set; }
        public Command RegisterCommand   {get;set; }
    }
}