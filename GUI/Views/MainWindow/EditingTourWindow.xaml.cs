using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.MainWindow
{
    public partial class EditingTourWindow : Window

    {
        private string ID;
        public EditingTourWindow(string id)
        {
            InitializeComponent();
            ID = id;
        }
        public string GetTourID()
        {
            return ID;
        }
        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void Cancel(object sender, MouseButtonEventArgs e)
        {
            
           
           var w2 = new TourDetailWindow(ID);
           w2.ShowDialog();
           Close();
        }
    }
}