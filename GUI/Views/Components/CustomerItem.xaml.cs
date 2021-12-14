using System.Windows.Controls;
using System.Windows.Input;
using GUI.Views.MainWindow;

namespace GUI.Views.Components
{
    public partial class CustomerItem : UserControl
    {
        public CustomerItem()
        {
            InitializeComponent();
        }

        private void CustomerItem_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var id = LbId.Content.ToString().Split(' ')[1];
            var w2 = new ProfileWindow(id);
            w2.ShowDialog();
        }
    }
}