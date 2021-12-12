using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using Color = System.Drawing.Color;

namespace GUI.Views.Pages
{
    public partial class PageStatistic_Tour : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        
        public PageStatistic_Tour()
        {
            InitializeComponent();
            var color = new SolidColorBrush
            {
                Color = Colors.LightGreen,
                Opacity = 0.1
            };
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 4, 0, 0, 0 ,4 },
                    Stroke = Brushes.DodgerBlue,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Net Profit",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    Stroke = Brushes.LimeGreen,
                    Fill = color,
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Quantity",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    Stroke = Brushes.Aqua,
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 10
                }
            };


            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };

            DataContext = this;
        }

        private void BtnRevenue_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetButtonStyle();
            BtnRevenue.Background = Brushes.White;
            TxtRevenue.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#3CA1FF");
        }

        private void BtnProfit_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetButtonStyle();
            BtnProfit.Background = Brushes.White;
            TxtProfit.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#3CA1FF");
        }

        private void ResetButtonStyle()
        {
            BtnRevenue.Background = Brushes.Transparent;
            BtnProfit.Background = Brushes.Transparent;
            TxtRevenue.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#949494");
            TxtProfit.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#949494");
        }
    }
}