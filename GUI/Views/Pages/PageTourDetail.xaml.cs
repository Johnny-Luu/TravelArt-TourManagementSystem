using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail : Page
    {
        public PageTourDetail()
        {
            InitializeComponent();
           

        }

        private void BtnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }


        private void LbInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrContainer.Content = new PageTourDetail_Info();
        }

        private void LbRating_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            FrContainer.Content = new PageTourDetail_Rating();
        }
        
        private void LbPlan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrContainer.Content = new PageTourDetail_Plan();
        }
    }
}