using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            const string fullStar = "pack://application:,,,/Assets/icons/goldstar_full.png";
            const string noStar = "pack://application:,,,/Assets/icons/goldstar_empty.png";
            const string halfStar = "pack://application:,,,/Assets/icons/goldstar_half.png";

           
            var converter = new ImageSourceConverter();
            ImgStar1.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar2.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar3.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar4.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar5.Source = (ImageSource)converter.ConvertFromString(noStar);

            var numHalfstars = (int)(score * 2.0f);
            if (numHalfstars >= 1) ImgStar1.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars >= 2) ImgStar1.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars >= 3) ImgStar2.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars >= 4) ImgStar2.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars >= 5) ImgStar3.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars >= 6) ImgStar3.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars >= 7) ImgStar4.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars >= 8) ImgStar4.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars >= 9) ImgStar5.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars >= 10) ImgStar5.Source = (ImageSource)converter.ConvertFromString(fullStar);

        }
    }
}