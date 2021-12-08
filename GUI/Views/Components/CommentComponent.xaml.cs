using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Schema;

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
            const string fullStar = "pack://application:,,,/Assets/icons/goldstar_full.png";
            const string noStar = "pack://application:,,,/Assets/icons/goldstar_empty.png";
            var converter = new ImageSourceConverter();
            ImgStar1.Source = (ImageSource)converter.ConvertFromString(fullStar);
            ImgStar2.Source = (ImageSource)converter.ConvertFromString(fullStar);
            ImgStar3.Source = (ImageSource)converter.ConvertFromString(fullStar);
            ImgStar4.Source = (ImageSource)converter.ConvertFromString(fullStar);
            ImgStar5.Source = (ImageSource)converter.ConvertFromString(fullStar);

            if (score < 5) ImgStar5.Source = (ImageSource)converter.ConvertFromString(noStar);
            if (score < 4) ImgStar4.Source = (ImageSource)converter.ConvertFromString(noStar);
            if (score < 3) ImgStar3.Source = (ImageSource)converter.ConvertFromString(noStar);
            if (score < 2) ImgStar2.Source = (ImageSource)converter.ConvertFromString(noStar);
            

        }
    }
}