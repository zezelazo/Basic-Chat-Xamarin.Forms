using BasicChat.Infraestructure;
using Xamarin.Forms;

namespace BasicChat.ViewModels
{
    public class FavsViewModel:BaseViewModel
    {
        public FavsViewModel()
        {
            LogoutCommand= new Command(()=>Application.Current.MainPage= new Views.Login.Login());
        }
        public Command LogoutCommand { get; set; }
    }
}