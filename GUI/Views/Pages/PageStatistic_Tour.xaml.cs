using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BLL;
using GUI.GlobalData;
using LiveCharts;
using LiveCharts.Wpf;
using Models;
using Color = System.Drawing.Color;

namespace GUI.Views.Pages
{
    public partial class PageStatistic_Tour : Page
    {
        private int totalRevenue = 0;
        private int totalProfit = 0;
        private int quantity = 0;
        private TourBLL tourBLL = new TourBLL();
        private List<TourModel> tourList = new List<TourModel>();

        private DateTime _today = DateTime.Now.Date;
        public SeriesCollection SeriesCollection { get; set; }
        private string[] LabelMonth = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string[] LabelDate = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        public PageStatistic_Tour()
        {
            InitializeComponent();
            
            LoadDataToCombobox();
            LoadDataAllTour();
            
            DataContext = this;
        }

        private async void LoadDataToCombobox()
        {
            // tour combobox
            tourList = await tourBLL.GetAllTour();
            foreach (var tour in tourList)
            {
                CbTour.Items.Add(tour.Id + "-" + tour.Name);
            }
            
            // month combobox
            CbMonth.ItemsSource = MonthData.MonthList;
            
            // year combobox
            CbYear.Items.Add("2021");
            CbYear.Items.Add("2020");
            CbYear.Items.Add("2019");
            CbYear.Items.Add("2018");
            CbYear.Items.Add("2017");
        }

        private async void LoadDataAllTour()
        {
            tourList = await tourBLL.GetAllTour();
            foreach (var tour in tourList)
            {
                LoadDataYearOneTour(tour.Id, 1);
            }
            
            Axis.Labels = LabelMonth;
        }

        private async void LoadDataYearOneTour(string id, int type, string yearChoose = "2021")
        {
            // reset data
            var revenueMonths = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var profitMonths = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            quantity = 0;

            // get tour data by id
            tourBLL = new TourBLL();
            var tour = await tourBLL.GetTourbyID(id);
            var singlePrice = tour.Price;
            var singleProfit = tour.Profit;

            // get tour group
            var TouGroupBLL = new TourGroupBLL();
            var tourGroupList = await TouGroupBLL.GetTourGroupByTourId(id);

            foreach (var tourGroup in tourGroupList)
            {
                var month = tourGroup.StartDate.Value.Month;
                var year = tourGroup.StartDate.Value.Year;
                
                // customerList not null and year choose = year
                if (!string.IsNullOrEmpty(tourGroup.CustomerList) && year == int.Parse(yearChoose))
                {
                    revenueMonths[month - 1] += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singlePrice);
                    profitMonths[month - 1] += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singleProfit);

                    if (type == 1)
                    {
                        totalRevenue += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singlePrice);
                        totalProfit += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singleProfit);
                    }
                }
                quantity++;
            }

            if (type == 1)
            {
                DrawChartAllTour(revenueMonths, tour.Name);
                UpdateInfoAllTour();
            }
            else
            {
                DrawCharYearOneTour(revenueMonths, profitMonths);
                UpdateInfoOneTour(revenueMonths, profitMonths);
            }
        }
        
        private async void LoadDataMonthOneTour(string id, string yearChoose = "2021", string monthChoose = "")
        {
            // reset data
            var revenueDay = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var profitDay = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            quantity = 0;

            // get tour data by id
            tourBLL = new TourBLL();
            var tour = await tourBLL.GetTourbyID(id);
            var singlePrice = tour.Price;
            var singleProfit = tour.Profit;

            // get tour group
            var TouGroupBLL = new TourGroupBLL();
            var tourGroupList = await TouGroupBLL.GetTourGroupByTourId(id);

            foreach (var tourGroup in tourGroupList)
            {
                var year = tourGroup.StartDate.Value.Year;
                var month = tourGroup.StartDate.Value.Month;
                var day = tourGroup.StartDate.Value.Day;
                
                // customerList not null and year choose = year
                if (!string.IsNullOrEmpty(tourGroup.CustomerList) && month == int.Parse(monthChoose) && year == int.Parse(yearChoose))
                {
                    revenueDay[day - 1] += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singlePrice);
                    profitDay[day - 1] += (tourGroup.CustomerList.Length/2 + 1) * int.Parse(singleProfit);
                }
                quantity++;
            }
            
            DrawCharMonthOneTour(revenueDay, profitDay);
            UpdateInfoOneTour(revenueDay, profitDay);
        }
        
        private void DrawCharYearOneTour(int[] arrRevenue, int[] arrProfit)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { arrRevenue[0], arrRevenue[1], arrRevenue[2], arrRevenue[3], arrRevenue[4], arrRevenue[5], arrRevenue[6], arrRevenue[7], arrRevenue[8], arrRevenue[9], arrRevenue[10], arrRevenue[11] },
                    Stroke = Brushes.DodgerBlue,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.DodgerBlue,
                        Opacity = 0.2
                    },
                    PointGeometrySize = 10,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                },
                new LineSeries
                {
                    Title = "Profit",
                    Values = new ChartValues<double> { arrProfit[0], arrProfit[1], arrProfit[2], arrProfit[3], arrProfit[4], arrProfit[5], arrProfit[6], arrProfit[7], arrProfit[8], arrProfit[9], arrProfit[10], arrProfit[11] },
                    Stroke = Brushes.LimeGreen,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.LimeGreen,
                        Opacity = 0.2
                    },
                    PointGeometrySize = 10,
                    PointGeometry = DefaultGeometries.Square,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                }
            };
            
            Chart.Series = SeriesCollection;
            Axis.Labels = LabelMonth;
        }
        
        private void DrawCharMonthOneTour(int[] arrRevenue, int[] arrProfit)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double>
                    {
                        arrRevenue[0], arrRevenue[1], arrRevenue[2], arrRevenue[3], arrRevenue[4], 
                        arrRevenue[5], arrRevenue[6], arrRevenue[7], arrRevenue[8], arrRevenue[9], 
                        arrRevenue[10], arrRevenue[11], arrRevenue[12], arrRevenue[13], arrRevenue[14], 
                        arrRevenue[15], arrRevenue[16], arrRevenue[17], arrRevenue[18], arrRevenue[19], 
                        arrRevenue[20], arrRevenue[21], arrRevenue[22], arrRevenue[23], arrRevenue[24], 
                        arrRevenue[25], arrRevenue[26], arrRevenue[27], arrRevenue[28], arrRevenue[29], 
                        arrRevenue[30]
                    },
                    Stroke = Brushes.DodgerBlue,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.DodgerBlue,
                        Opacity = 0.2
                    },
                    PointGeometrySize = 10,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                },
                new LineSeries
                {
                    Title = "Profit",
                    Values = new ChartValues<double>
                    {
                        arrProfit[0], arrProfit[1], arrProfit[2], arrProfit[3], arrProfit[4], 
                        arrProfit[5], arrProfit[6], arrProfit[7], arrProfit[8], arrProfit[9], 
                        arrProfit[10], arrProfit[11], arrProfit[12], arrProfit[13], arrProfit[14], 
                        arrProfit[15], arrProfit[16], arrProfit[17], arrProfit[18], arrProfit[19], 
                        arrProfit[20], arrProfit[21], arrProfit[22], arrProfit[23], arrProfit[24], 
                        arrProfit[25], arrProfit[26], arrProfit[27], arrProfit[28], arrProfit[29], 
                        arrProfit[30]
                    },
                    Stroke = Brushes.LimeGreen,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.LimeGreen,
                        Opacity = 0.2
                    },
                    PointGeometrySize = 10,
                    PointGeometry = DefaultGeometries.Square,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                }
            };
            
            Chart.Series = SeriesCollection;
            Axis.Labels = LabelDate;
        }
        
        private void DrawChartAllTour(int[] arrRevenue, string name)
        {
            Random r = new Random();
            Brush stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(ColorData.ColorCodes[r.Next(0, ColorData.ColorCodes.Length)]);
            
            var fill = new SolidColorBrush
            {
                Color = ((SolidColorBrush) stroke).Color,
                Opacity = 0.1
            };

            var line = new LineSeries
            {
                Title = name,
                Values = new ChartValues<double>
                {
                    arrRevenue[0], arrRevenue[1], arrRevenue[2], arrRevenue[3], arrRevenue[4], arrRevenue[5],
                    arrRevenue[6], arrRevenue[7], arrRevenue[8], arrRevenue[9], arrRevenue[10], arrRevenue[11]
                },
                Stroke = stroke,
                Fill = fill,
                PointGeometrySize = 10,
                PointGeometry = DefaultGeometries.None,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString("N0"),
            };
            
            Chart.Series.Add(line);
        }
        
        private void UpdateInfoOneTour(int[] arrRevenue, int[] arrProfit)
        {
            int revenue = 0;
            int profit = 0;
            
            for (int i = 0; i < 12; i++)
            {
                revenue += arrRevenue[i];
                profit += arrProfit[i];
            }
            
            LbRevenue.Content = revenue.ToString("N0");
            LbProfit.Content = profit.ToString("N0");
            LbQuantity.Content = quantity.ToString("N0");
        }
        
        private void UpdateInfoAllTour()
        {
            LbRevenue.Content = totalRevenue.ToString("N0");
            LbProfit.Content = totalProfit.ToString("N0");
            LbQuantity.Content = quantity.ToString("N0");
        }

        private void BtnRevenue_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetButtonStyle();
            BtnRevenue.Background = Brushes.White;
            TxtYear.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#3CA1FF");
        }

        private void BtnProfit_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetButtonStyle();
            BtnProfit.Background = Brushes.White;
            TxtMonth.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#3CA1FF");
        }

        private void ResetButtonStyle()
        {
            BtnRevenue.Background = Brushes.Transparent;
            BtnProfit.Background = Brushes.Transparent;
            TxtYear.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#949494");
            TxtMonth.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#949494");
        }

        private void CbTour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = CbTour.SelectedItem.ToString().Split('-')[0];
            LoadDataYearOneTour(id, 2);
            CbYear.SelectedIndex = 0;
            CbMonth.SelectedIndex = -1;
        }

        private void CbYear_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = CbTour.SelectedItem.ToString().Split('-')[0];
            LoadDataYearOneTour(id, 2,CbYear.SelectedItem.ToString());
            CbMonth.SelectedIndex = -1;
        }

        private void CbMonth_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbMonth.SelectedIndex == -1) return;
            var id = CbTour.SelectedItem.ToString().Split('-')[0];
            LoadDataMonthOneTour(id, CbYear.SelectedItem.ToString(), CbMonth.SelectedItem.ToString());
        }
    }
}