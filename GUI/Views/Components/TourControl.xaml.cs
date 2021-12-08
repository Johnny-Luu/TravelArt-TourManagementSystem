using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
    }
}