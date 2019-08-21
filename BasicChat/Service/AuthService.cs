using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BasicChat.Infraestructure;
using BasicChat.Views;
using BasicChat.Views.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BasicChat.Service
{
    public class AuthService
    {
        
        public async Task<SimpleServiceResponse<bool>> Login(string username, string password)
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    if (username != password)
                        return new SimpleServiceResponse<bool>(EResponseType.Ok, false);

                    Settings.Username = username;
                    Settings.Password = password;
                    Settings.IsUserLoggedIn = true;
                    //await NavigationHelper.Navigator.PushAsync(new MainPage());
                    Application.Current.MainPage = new MainPage();
                    return new SimpleServiceResponse<bool>(EResponseType.Ok, true);

                }
                else
                {
                    return new SimpleServiceResponse<bool>(EResponseType.NoConnection, false,
                        "No network connectivity");
                }
            }
            catch (NetworkInformationException e)
            {
                return new SimpleServiceResponse<bool>(EResponseType.NoConnection, false,
                    "No network connectivity");
            }
            catch (Exception e)
            {
                return new SimpleServiceResponse<bool>(EResponseType.Exception, false, e.Message);
            }
        }

        public async Task LogOut()
        {
            Settings.Username = string.Empty;
            Settings.Password = string.Empty;
            Settings.IsUserLoggedIn = false;
            Application.Current.MainPage = new NavigationPage( new Login());
            //await NavigationHelper.Navigator.PushAsync(new Login());
        }
    }
}
