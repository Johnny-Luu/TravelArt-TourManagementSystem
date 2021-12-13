using System;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Media;
using FunctionLibrary;
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
            RatingChartRatio.Ratio(r1, r2, r3, r4, r5, out var ratio1, out var ratio2, out var ratio3, out var ratio4,
                out var ratio5);
            RecRating1.Width = maxLenght * ratio1;
            RecRating2.Width = maxLenght * ratio2;
            RecRating3.Width = maxLenght * ratio3;
            RecRating4.Width = maxLenght * ratio4;
            RecRating5.Width = maxLenght * ratio5;
            //Set number
            var totalRating = r1 + r2 + r3 + r4 + r5;
            LbNumberRating.Content = "Total: " + totalRating.ToString();
            double score =((r1 + r2 * 2 + r3 * 3 + r4 * 4 + r5 * 5) * 1.0) / totalRating;
            LbScore.Content = score.ToString("0.0");
            //Exception no rating
            if(r1+r2+r3+r4+r5==0) LbScore.Content = "0.0";
            //set star
            StarInit(score);
        }

        private void StarInit( double score)
        {

            StarSetUp.SetUpStar(StarSetUp.ScoreToStar(score),out var s1,out var s2,out var s3,out var s4,out var s5);
            ImgStar1.Source = StarSetUp.SetUpPath(s1);
            ImgStar2.Source = StarSetUp.SetUpPath(s2);
            ImgStar3.Source = StarSetUp.SetUpPath(s3);
            ImgStar4.Source = StarSetUp.SetUpPath(s4);
            ImgStar5.Source = StarSetUp.SetUpPath(s5);
            
        }
    }
}