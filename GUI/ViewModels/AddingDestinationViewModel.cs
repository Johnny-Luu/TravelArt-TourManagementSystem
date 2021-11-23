using System.Windows.Input;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class AddingDestinationViewModel : BaseViewModel
    {
        public PageAddingDestination PgAddingDestination { get; set; }
        public ICommand PushDestinationCommand { get; set; }
        
        public AddingDestinationViewModel()
        {
            PushDestinationCommand = new RelayCommand<PageAddingDestination>(para => true, para => PushDestination(para));
        }

        public async void PushDestination(PageAddingDestination para)
        {
            // TODO: implement adding destination
        }
    }
}