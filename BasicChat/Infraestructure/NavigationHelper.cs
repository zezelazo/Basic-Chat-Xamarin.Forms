using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BasicChat.Infraestructure
{
    public class NavigationHelper
    {
        public static INavigation Navigator => Application.Current.MainPage.Navigation;

        public static void PopAsync(bool animate = true)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {

            Navigator.PopAsync(animate);
            });
        }

        public static void PushAsync(Page newPage)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {

                Navigator.PushAsync(newPage);
            }); 
        }
    }
}
