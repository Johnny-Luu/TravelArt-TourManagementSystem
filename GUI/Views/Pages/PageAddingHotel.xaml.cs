using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageAddingHotel : Page
    {
        public PageAddingHotel()
        {
            InitializeComponent();
        }
        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}