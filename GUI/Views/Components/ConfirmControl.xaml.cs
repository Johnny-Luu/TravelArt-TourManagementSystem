using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;

namespace GUI.Views.Components
{
    public partial class ConfirmControl : UserControl
    {
        public ConfirmControl()
        {
            InitializeComponent();
        }

        private async void Accept_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var tourGroupId = LbTourGroupId.Content.ToString();
            var customerId = LbCustomerId.Content.ToString().Split(' ')[1];
            
            // add customer to tour group
            var tourGroupBLL = new TourGroupBLL();
            var result = await tourGroupBLL.AddTourismToList(tourGroupId, customerId);

            if (result)
            {
                MessageBox.Show("Accepted successfully!");
                var requestBLL = new RequestBLL();
                await requestBLL.DeleteRequest(LbRequestId.Content.ToString());
            }
            else
            {
                MessageBox.Show("Accepted failed!");
            }
        }

        private async void Decline_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var requestBLL = new RequestBLL();
            await requestBLL.DeleteRequest(LbRequestId.Content.ToString());
        }
    }
}