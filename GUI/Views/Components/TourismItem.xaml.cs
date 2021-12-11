using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;

namespace GUI.Views.Components
{
    public partial class TourismItem : UserControl
    {
        public TourismItem()
        {
            InitializeComponent();
        }

        private async void BtnDelete_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var tourGroupId = LbTourGroupId.Content.ToString();
            var customerId = LbId.Content.ToString().Split(' ')[1];
            
            var tourGroupBLL = new TourGroupBLL();
            var result = await tourGroupBLL.RemoveTourismFromList(tourGroupId, customerId);
            MessageBox.Show(result ? "Delete successfully!" : "Delete failed!");
        }
    }
}