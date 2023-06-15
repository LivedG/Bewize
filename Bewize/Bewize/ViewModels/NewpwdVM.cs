using System;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.Views.Signup_Login;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace Bewize.ViewModels
{
	public class NewpwdVM : BaseViewModel
	{
        public screenbackbtnCommand newpwdBackbtnCommand;


        public NewpwdVM()
		{
            newpwdBackbtnCommand = new screenbackbtnCommand(this);
		}

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public async void SetupPassword_CompletedRegistration(Forgetpassword_reqpara newpwd)
        {
            try
            {

                string webURL = APIHelper.Forgotpwd;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(newpwd));

                if (res.success)
                {

                    //await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                    App.Current.MainPage.Navigation.PushAsync(new RegisterwithNo_DonePage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
              
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }
            
        }


    }

    public class screenbackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private NewpwdVM VM;

        public screenbackbtnCommand(NewpwdVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }

    }
}

