using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.MainWindow
{
    public partial class EditingTourWindow : Window

    {
        public EditingTourWindow()
        {
            InitializeComponent();
        }

        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void Cancel(object sender, MouseButtonEventArgs e)
        {
           Close();
        }
    }
}