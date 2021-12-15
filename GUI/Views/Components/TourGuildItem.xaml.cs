using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using GUI.Views.MainWindow;
using GUI.Views.Pages;

namespace GUI.Views.Components
{
    public partial class TourGuildItem : UserControl
    {
        public TourGuildItem()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var tourID = LbTourGroupID.Content.ToString().Split(' ')[1];
            TourGroupDetailWindow w2 = new TourGroupDetailWindow(tourID);
            w2.ShowDialog();
        }

        private void Delete_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Do you want to delete this tour group?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var id = LbTourGroupID.Content.ToString().Split(' ')[1];
                var tourGroupBLL = new TourGroupBLL();
                tourGroupBLL.DeleteTourGroup(id);
                MessageBox.Show("Delete tour group successfully!");
            }
        }
    }
}