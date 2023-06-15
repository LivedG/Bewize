using System;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.Views;
using Bewize.Views.Signup_Login;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
	public class ResetpwdVM:BaseViewModel
	{
      //  public Resetpwd_btnCommand resetpwdCommand { get; set; }
        public Resetpwd_BackbtnCommand resetpwdBackbtnCommand { get; set; }

        private Verifyotp_reqPara _RequestPara_verifyotp { get; set; }
        public Verifyotp_reqPara RequestPara_verifyotp
        {
            get { return _RequestPara_verifyotp; }
            set
            {
                _RequestPara_verifyotp = value;
                OnPropertyChanged();
            }
        }

        public ResetpwdVM()
		{
           // resetpwdCommand = new Resetpwd_btnCommand(this);
            resetpwdBackbtnCommand = new Resetpwd_BackbtnCommand(this);

        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public async void MoveForwardResetpwdprocess(Users_reqPara _Reqpara)
        {
            
            try
            {

                string webURL = APIHelper.Forgotpwd;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(_Reqpara));
                if (res.success)
                {

                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                    App.Current.MainPage.Navigation.PushAsync(new SigninPage());
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

    public class Resetpwd_BackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ResetpwdVM VM;

        public Resetpwd_BackbtnCommand(ResetpwdVM vm)
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


    //public class Resetpwd_btnCommand : ICommand
    //{
    //    public event EventHandler CanExecuteChanged;

    //    private ResetpwdVM VM;

    //    public Resetpwd_btnCommand(ResetpwdVM vm)
    //    {
    //        VM = vm;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        VM.MoveForwardResetpwdprocess();
    //    }
    //}

}

