using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;

namespace Bewize.ViewModels
{
	public class LocationDetailsVM
	{
        public ClosebtnActionCommand popupClosebtn { get; set; }
        public ViewDetailsbtnActionCommand ViewDetailsbtn { get; set; }


        public LocationDetailsVM()
		{
            popupClosebtn = new ClosebtnActionCommand(this);
            ViewDetailsbtn = new ViewDetailsbtnActionCommand(this);
		}

        public async Task ClosepopupViewAsync()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public void ViewLocationDetails()
        {
            PopupNavigation.Instance.PopAsync();
            App.Current.MainPage.Navigation.PushAsync(new Views.Home.LocationScore_RatingPage());
        }

    }


    public class ClosebtnActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LocationDetailsVM VM;

        public ClosebtnActionCommand(LocationDetailsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.ClosepopupViewAsync();
        }

    }

    public class ViewDetailsbtnActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LocationDetailsVM VM;

        public ViewDetailsbtnActionCommand(LocationDetailsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.ViewLocationDetails();
        }

    }

}

