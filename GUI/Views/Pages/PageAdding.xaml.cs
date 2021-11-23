using System.Windows.Controls;
using GUI.Views.Pages;
using GUI.Views.Pages;

namespace GUI.Views.Pages
{
    public partial class PageAdding : Page
    {
        public PageAdding()
        {
            InitializeComponent();
            var destinationOfPageAdding = new PageAddingHotel();
            FrAddingContainer.Content = destinationOfPageAdding;
        }
    }
}