using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Schema;
using FunctionLibrary;

namespace GUI.Views.Components
{
    public partial class CommentComponent : UserControl
    {
        public int score=0;
        public CommentComponent()
        {
            InitializeComponent();
         
        }
        public void InitStar()
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