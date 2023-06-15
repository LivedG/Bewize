using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bewize.ViewModels
{
	public class LocationScore_RatingVM : BaseViewModel
	{
        public Backtohome_Command backcmd { get; set; }

        public LocationScore_RatingVM()
        {
            backcmd = new Backtohome_Command(this);

        }

        public void MoveBackwardScreen()
        {
                App.Current.MainPage.Navigation.PopAsync();
        }

        public class Backtohome_Command : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private LocationScore_RatingVM VM;

            public Backtohome_Command(LocationScore_RatingVM vm)
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
}

