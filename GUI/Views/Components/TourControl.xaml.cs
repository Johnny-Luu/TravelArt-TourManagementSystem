using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BLL;
using FunctionLibrary;
using GUI.Views.Components;
using GUI.Views.MainWindow;
using GUI.Views.Pages;

namespace GUI.Components
{
    public partial class TourControl : UserControl
    {
        public string tourID = "0";
        public TourControl()
        {
            InitializeComponent();
        }


        private void MouseDown_TourDetail(object sender, MouseButtonEventArgs e)
        {
            TourDetailWindow w2 = new TourDetailWindow(tourID);
            w2.ShowDialog();
        }
        public void StarInit(double score)
        {
            StarSetUp.SetUpStar(StarSetUp.ScoreToStar(score),out var s1,out var s2,out var s3,out var s4,out var s5);
            ImgStar1.Source = StarSetUp.SetUpPath(s1);
            ImgStar2.Source = StarSetUp.SetUpPath(s2);
            ImgStar3.Source = StarSetUp.SetUpPath(s3);
            ImgStar4.Source = StarSetUp.SetUpPath(s4);
            ImgStar5.Source = StarSetUp.SetUpPath(s5);

        }

        private async void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Do you want to delete this tour?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var tourBLL = new TourBLL();
                var check = await tourBLL.ExistReference(tourID);
                
                if(check) MessageBox.Show("Some tour group currently using this tour, can not delete now!");
                else
                {
                    tourBLL.DeleteTour(tourID);
                    MessageBox.Show("Delete tour successfully!");
                }
            }
        }
    }
}