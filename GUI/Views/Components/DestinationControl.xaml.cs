using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using GUI.Views.MainWindow;

namespace GUI.Views.Components
{
    public partial class DestinationControl : UserControl
    {
        public DestinationControl()
        {
            InitializeComponent();
        }

        private void DestinationControl_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var id = LbId.Content.ToString();
            var w2 = new DestinationDetailWindow(id);
            w2.ShowDialog();
        }

        private async void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Do you want to delete destination?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var id = LbId.Content.ToString();
                var destinationBLL = new DestinationBLL();
                var check = await destinationBLL.ExistReference(id);
                
                if(check) MessageBox.Show("Some tour currently using this destination, can not delete now!");
                else
                {
                    destinationBLL.DeleteDestination(id);
                    MessageBox.Show("Delete destination successfully!");
                }
            }
        }
    }
}