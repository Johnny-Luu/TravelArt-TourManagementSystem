using System.Windows.Controls;
using GUI.Pages;

namespace GUI.Pages
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