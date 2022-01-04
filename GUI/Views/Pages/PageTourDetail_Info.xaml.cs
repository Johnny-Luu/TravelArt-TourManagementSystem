using System;
using System.Windows.Controls;
using System.Windows.Input;
using GUI.Views.MainWindow;
using Models;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Info : Page
    {
        public PageTourDetail_Info( )
        {
            InitializeComponent();
        }

   
    public void Set_LbPrice(long s)
    {
        //s.ToString(@"#\.###\.###\.##0")
        string moneyString = String.Format("{0:0,0}", s);
        LbPrice.Content = "Price: " + moneyString + " VND";
    }
    public void Set_LbDuration(int d, int n)
    {
        string res = "Duration: " + d.ToString() +" Day";
        if (d > 1) res += "s";
        res += " " + n + " Night";
        if(n>1) res += "s";
        LbDuration.Content = res;
    }
    
    public void Set_LbVisit(string s)
    {
        LbVisit.Content = "Visit: " + s + " Locations";
    }

    private void EditTour(object sender, MouseButtonEventArgs e)
    {
        var w2 = new EditingTourWindow();
        w2.ShowDialog();
    }
    }
}