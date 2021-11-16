using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail : Page
    {
        public PageTourDetail()
        {
            InitializeComponent();
            ResizeAllSlider();
        }

        private void BtnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ResizeAllSlider()
        {
            ResizeSlider(ImgSlider1);
            ResizeSlider(ImgSlider2);
            ResizeSlider(ImgSlider3);
            ResizeSlider(ImgSlider4);
        }
        private void ResizeSlider(Image img)
        {
            img.Width = 14;
            img.Height = 14;
        }
        private void ToggleSlider(Image img)
        {
            img.Width = 20;
            img.Height = 20;
        }
        #region Slider button

        private void ImgSlider4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ResizeAllSlider();
            ToggleSlider(ImgSlider4);
            
        }

        private void ImgSlider3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ResizeAllSlider();
            ToggleSlider(ImgSlider3);
            
        }
        private void ImgSlider2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ResizeAllSlider();
            ToggleSlider(ImgSlider2);
            
        }

        private void ImgSlider1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            ResizeAllSlider();
            ToggleSlider(ImgSlider1);
           
            
        }
        #endregion
    }
}