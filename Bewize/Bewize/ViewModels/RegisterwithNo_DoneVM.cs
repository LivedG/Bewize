using System;
namespace Bewize.ViewModels
{
	public class RegisterwithNo_DoneVM
	{
		public RegisterwithNo_DoneVM()
		{
		}

		public void registrationsuccessfullywithPhonenumber() {
            App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
        }
	}
}

