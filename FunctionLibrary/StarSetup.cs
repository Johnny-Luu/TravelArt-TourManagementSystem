using System.Windows.Media;

namespace FunctionLibrary
{
    public static class StarSetUp
    {
        private const string FullStar = "pack://application:,,,/Assets/icons/goldstar_full.png";
        private const string NoStar = "pack://application:,,,/Assets/icons/goldstar_empty.png";
        private const string HalfStar = "pack://application:,,,/Assets/icons/goldstar_half.png";
        public static int ScoreToStar(double score)  //1 for each half star
        {
            if (score > 5 || score < 0) return -1;
            return (int) (score * 2.0f);
        }

        public static bool SetUpStar(int star, out int star1, out int star2, out int star3, out int star4,
            out int star5)
        {
           
            //0: no star, 1:half star, 2=full star
            star1 = 0;
            star2 = 0;
            star3 = 0;
            star4 = 0;
            star5 = 0;
            if (star < 0 || star > 10) return false;
            
            if (star >= 1) star1 = 1;
            if (star >= 2) star1 = 2;
            if (star >= 3) star2 = 1;
            if (star >= 4) star2 = 2;
            if (star >= 5) star3 = 1;
            if (star >= 6) star3 = 2;
            if (star >= 7) star4 = 1;
            if (star >= 8) star4 = 2;
            if (star >= 9) star5 = 1;
            if (star >= 10) star5 = 2;
            return true;
        }

        public static ImageSource SetUpPath(int star)
        {
            var converter = new ImageSourceConverter();
            switch (star)
            {
                case 0:
                {
                    return (ImageSource)converter.ConvertFromString(NoStar);
                }
                case 1:
                {
                    return (ImageSource)converter.ConvertFromString(HalfStar);
                }
                case 2:
                {
                     return (ImageSource)converter.ConvertFromString(FullStar);
                }
                default: return (ImageSource)converter.ConvertFromString(NoStar);
            }

        }
    }
}