using System;
using BasicChat.Views;
using BasicChat.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            if (Settings.IsUserLoggedIn)
            {
                MainPage = new MainPage();
            }
            else
            {
                MyNavigationPage= new NavigationPage(new Login());
                MainPage =  MyNavigationPage ;
            }
        }

        public NavigationPage MyNavigationPage { get; set; }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
