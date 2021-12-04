using System.Windows.Controls;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageConfirm : Page
    {
        public PageConfirm()
        {
            var item1 = new ConfirmControl();
            var item2 = new ConfirmControl();
            var item3 = new ConfirmControl();
            var item4 = new ConfirmControl();
            var item9 = new ConfirmControl();
            var item5 = new ConfirmControl();
            var item6 = new ConfirmControl();
            var item7 = new ConfirmControl();
            var item8 = new ConfirmControl();
            InitializeComponent();
            WpListConfirm.Children.Add(item1);
            WpListConfirm.Children.Add(item2);
            WpListConfirm.Children.Add(item3);
            WpListConfirm.Children.Add(item4);
            WpListConfirm.Children.Add(item5);
            WpListConfirm.Children.Add(item6);
            WpListConfirm.Children.Add(item7);
            WpListConfirm.Children.Add(item8);
            WpListConfirm.Children.Add(item9);
        }
    }
}