using System;
using System.Windows.Input;
using Bewize.Views;

namespace Bewize.ViewModels
{
    public class MainPageVM
    {
        public NewSignupCommand Signup_command { get; set; }
        public LoginCommand Login_Command { get; set; }

        public MainPageVM()
        {
            Signup_command = new NewSignupCommand(this);
            Login_Command = new LoginCommand(this);
        }

        public void MovetoSignupOptions()
        {
            App.Current.MainPage.Navigation.PushAsync(new SignupPage());
        }

        public void MovetoLoginOptions()
        {
            App.Current.MainPage.Navigation.PushAsync(new SigninPage());
        }
    }

    public class NewSignupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainPageVM VM;
        public NewSignupCommand(MainPageVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MovetoSignupOptions();
        }
    }

    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainPageVM VM;
        public LoginCommand(MainPageVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MovetoLoginOptions();
        }
    }
}

