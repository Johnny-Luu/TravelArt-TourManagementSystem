using System;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Media;

namespace GUI.Views.Components
{
    public partial class TourRating : UserControl
    {
        public TourRating()
        {

            InitializeComponent();
        }

 

        private float MaxRate(int r1, int r2, int r3, int r4, int r5)
        {
            var max = r1;
            if (r2 > max) max = r2;
            if (r3 > max) max = r3;
            if (r4 > max) max = r4;
            if (r5 > max) max = r5;

            return max;
        }
        public void RatingChartInit(int r1, int r2, int r3, int r4, int r5)
        {
            const int maxLenght = 140;
            var maxRate=MaxRate(r1,r2,r3,r4,r5);
            //Set chart lenght
            RecRating1.Width = maxLenght * (r1*1.0/ maxRate);
            RecRating2.Width = maxLenght * (r2*1.0/ maxRate);
            RecRating3.Width = maxLenght * (r3*1.0/ maxRate);
            RecRating4.Width = maxLenght * (r4*1.0/ maxRate);
            RecRating5.Width = maxLenght * (r5*1.0/ maxRate);
            //Set number
            var totalRating = r1 + r2 + r3 + r4 + r5;
            LbNumberRating.Content = "Total: " + totalRating.ToString();
            double score =((r1 + r2 * 2 + r3 * 3 + r4 * 4 + r5 * 5) * 1.0) / totalRating;
            LbScore.Content = score.ToString("0.0");
            //set star
            StarInit(score);
        }

        private void StarInit( double score)
        {
            ////////////////////////////////////////////
           //Kiếm được hình ngôi sao thì đổi mấy cái path này
           ///////////////////////////////////////////////
            const string fullStar = "pack://application:,,,/Assets/icons/goldstar_full.png";
            const string noStar = "pack://application:,,,/Assets/icons/goldstar_empty.png";
            const string halfStar = "pack://application:,,,/Assets/icons/goldstar_half.png";
            
            var converter = new ImageSourceConverter();
            ImgStar1.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar2.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar3.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar4.Source = (ImageSource)converter.ConvertFromString(noStar);
            ImgStar5.Source = (ImageSource)converter.ConvertFromString(noStar);
            
            var numHalfstars = (int) (score * 2.0f);
            if (numHalfstars>=1) ImgStar1.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars>=2) ImgStar1.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars>=3) ImgStar2.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars>=4) ImgStar2.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars>=5) ImgStar3.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars>=6) ImgStar3.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars>=7) ImgStar4.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars>=8) ImgStar4.Source = (ImageSource)converter.ConvertFromString(fullStar);
            if (numHalfstars>=9) ImgStar5.Source = (ImageSource)converter.ConvertFromString(halfStar);
            if (numHalfstars>=10) ImgStar5.Source = (ImageSource)converter.ConvertFromString(fullStar);
            
        }
    }
}