using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail : Page
    {
        public PageTourDetail()
        {
            InitializeComponent();
            FrContainer.Content = new PageTourDetail_Rating();

        }

        private void BtnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        
    }
}