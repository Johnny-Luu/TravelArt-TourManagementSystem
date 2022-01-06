using System.Windows;
using System.Windows.Input;

namespace GUI.Views.MainWindow
{
    public partial class EditingDestinationWindow : Window
    {
        public EditingDestinationWindow()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}