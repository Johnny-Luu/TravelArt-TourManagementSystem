using System.Windows.Controls;
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
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 },
                    // Stroke = System.Windows.Media.Brushes.DodgerBlue,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Net Profit",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    // Stroke = System.Windows.Media.Brushes.LimeGreen,
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Quantity",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    // Stroke = System.Windows.Media.Brushes.Aqua,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 10
                }
            };


            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };

            DataContext = this;
        }
    }
}