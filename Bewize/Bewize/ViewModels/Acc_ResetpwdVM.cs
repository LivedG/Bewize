using System;
using System.Windows.Input;
using Bewize.Models;
using Bewize.HelperResource;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
    public class Acc_ResetpwdVM : BaseViewModel
    {
       // public UpdatepwdSuccessfullyCommand Continuebtn_Command { get; set; }
        public resetpwd_backbtnCommand backbtn_Command { get; set; }

        public Acc_ResetpwdVM()
        {
         //   Continuebtn_Command = new UpdatepwdSuccessfullyCommand(this);
            backbtn_Command = new resetpwd_backbtnCommand(this);

        }

        public async void Sucessfullychangedpwd(string pwdstring)
        {
              try
                {
                    Resetpassword pwdstr = new Resetpassword();
                    pwdstr.password = pwdstring;
                    string webURL = APIHelper.Resetpwd;
                    HttpHelper httpHelper = new HttpHelper();
                    APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(pwdstr));
                   
                    if (res.success)
                    {
                        UserDetails details = new UserDetails();
                        string obj = JsonConvert.SerializeObject(res.data);
                        details = JsonConvert.DeserializeObject<UserDetails>(obj);
                        App.Current.MainPage.Navigation.PushAsync(new Views.Home.MyHomepage());

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


        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }


    //public class UpdatepwdSuccessfullyCommand : ICommand
    //{
    //    public event EventHandler CanExecuteChanged;

    //    private Acc_ResetpwdVM VM;

    //    public UpdatepwdSuccessfullyCommand(Acc_ResetpwdVM vm)
    //    {
    //        VM = vm;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        VM.Sucessfullychangedpwd();
    //    }
    //}

    public class resetpwd_backbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Acc_ResetpwdVM VM;

        public resetpwd_backbtnCommand(Acc_ResetpwdVM vm)
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

