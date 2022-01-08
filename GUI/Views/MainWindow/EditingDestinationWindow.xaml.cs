using System.Windows;
using System.Windows.Input;

namespace GUI.Views.MainWindow
{
    public partial class EditingDestinationWindow : Window
    {
        private string ID;
        public EditingDestinationWindow(string id)
        {
            InitializeComponent();
            ID = id;
        }
        public string GetDesID()
        {
            return ID;
        }
        private void Cancel(object sender, MouseButtonEventArgs e)
        {
            var w2 = new DestinationDetailWindow(ID);
            w2.ShowDialog();
            Close();
        }
    }
}