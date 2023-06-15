using System;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bewize.ViewModels
{
	public class SelectedLocationDetailsVM
	{
        public popupClosebtnActionCommand popupClosebtn { get; set; }
        public selectedLocationDetailsbtnActionCommand LocationDetailsbtn { get; set; }

        public SelectedLocationDetailsVM()
        {

            popupClosebtn = new popupClosebtnActionCommand(this);
            LocationDetailsbtn = new selectedLocationDetailsbtnActionCommand(this);
        }

        public async Task ClosepopupViewAsync()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public void ViewLocationDetails()
        {
            PopupNavigation.Instance.PopAsync();
            //App.Current.MainPage.Navigation.PushAsync(new Views.Home.SelectedLocationFullDetails());
        }

    }


    public class popupClosebtnActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SelectedLocationDetailsVM VM;

        public popupClosebtnActionCommand(SelectedLocationDetailsVM vm)
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

    public class selectedLocationDetailsbtnActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SelectedLocationDetailsVM VM;

        public selectedLocationDetailsbtnActionCommand(SelectedLocationDetailsVM vm)
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

