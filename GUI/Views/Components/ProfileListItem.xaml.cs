using System.Windows.Controls;
using System.Windows.Input;
using GUI.Views.MainWindow;

namespace GUI.Views.Components
{
    public partial class ProfileListItem : UserControl
    {
        public ProfileListItem()
        {
            InitializeComponent();
        }

        private void ProfileListItem_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var id = LbTourGroupId.Content.ToString();
            var w2 = new TourGroupDetailWindow(id);
            w2.ShowDialog();
        }
    }
}