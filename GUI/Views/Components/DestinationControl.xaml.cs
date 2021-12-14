using System.Windows.Controls;
using System.Windows.Input;
using GUI.Views.MainWindow;

namespace GUI.Views.Components
{
    public partial class DestinationControl : UserControl
    {
        public DestinationControl()
        {
            InitializeComponent();
        }

        private void DestinationControl_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var id = LbId.Content.ToString();
            var w2 = new DestinationDetailWindow(id);
            w2.ShowDialog();
        }
    }
}