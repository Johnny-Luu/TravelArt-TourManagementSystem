using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
    }
}