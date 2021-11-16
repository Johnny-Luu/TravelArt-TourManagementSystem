using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

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
        private void ResizeSlider(Ellipse img)
        {
            img.Width = 6;
            img.Height = 6;
        }
        private void ToggleSlider(Ellipse img)
        {
            img.Width = 14;
            img.Height = 14;
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