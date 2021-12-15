namespace FunctionLibrary
{
    public static class RatingChartRatio
    {
        private static double MaxRate(int r1, int r2, int r3, int r4, int r5)
        {
            var max = r1;
            if (r2 > max) max = r2;
            if (r3 > max) max = r3;
            if (r4 > max) max = r4;
            if (r5 > max) max = r5;

            return max;
        }

        public static bool Ratio(int r1,int r2,int r3, int r4, int r5, out double ratio1, out double ratio2, out double ratio3, out double ratio4, out double ratio5)
        {
            
            if (r1 < 0 || r2 < 0 || r3 < 0 || r4 < 0 || r5 < 0 ||(r1 == 0 && r2 == 0 && r3 == 0 && r4 == 0 && r5 == 0))
            {
                ratio1 = 0;
                ratio2 = 0;
                ratio3 = 0;
                ratio4 = 0;
                ratio5 = 0;
                return false;
            }

            var maxRate = MaxRate(r1, r2, r3, r4, r5);
            ratio1= r1*1.0/ maxRate;
            ratio2= r2*1.0/ maxRate;
            ratio3= r3*1.0/ maxRate;
            ratio4= r4*1.0/ maxRate;
            ratio5= r5*1.0/ maxRate;
            return true;
        }
    }
}