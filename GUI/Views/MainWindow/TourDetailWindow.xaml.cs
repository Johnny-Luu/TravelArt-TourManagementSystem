using System.Windows;
using System.Windows.Input;
using GUI.Views.Pages;

namespace GUI.Views.MainWindow

{
    public partial class TourDetailWindow : Window
    {
        public TourDetailWindow()
        {
            InitializeComponent();
            FrContainer.Content = new PageTourDetail_Info();
        }
        private void BtnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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