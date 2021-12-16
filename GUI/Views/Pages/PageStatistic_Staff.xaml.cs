using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL;
using DTO;
using GUI.GlobalData;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32.SafeHandles;

namespace GUI.Views.Pages
{
    public partial class PageStatistic_Staff : Page
    {
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private List<EmployeeModel> employeeList = new List<EmployeeModel>();
        private TourGroupBLL tourGroupBLL = new TourGroupBLL();
        private List<TourGroupModel> tourGroupList = new List<TourGroupModel>();
        
        private int colorIndex = 0;
        
        public SeriesCollection SeriesCollection { get; set; }
        private string[] LabelMonth = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string[] LabelDate = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

        public PageStatistic_Staff()
        {
            InitializeComponent();

            LoadDataToCombobox();
        }

        private async void LoadDataToCombobox()
        {
            employeeList = await employeeBLL.GetAllEmployee();
            tourGroupList = await tourGroupBLL.GetAllTourGroup();
            
            // employee combobox
            CbEmployee.Items.Add("All");
            foreach (var employee in employeeList)
            {
                CbEmployee.Items.Add(employee.Id + "-" + employee.Name);
            }
            
            // month combobox
            CbMonth.ItemsSource = MonthData.MonthList;
            
            // year combobox
            CbYear.Items.Add("2021");
            CbYear.Items.Add("2020");
            CbYear.Items.Add("2019");
            CbYear.Items.Add("2018");
            CbYear.Items.Add("2017");
            
            CbEmployee.SelectedIndex = 0;
        }
        
        private void LoadDataAllEmployee()
        {
            Chart.Series.Clear();
            foreach (var employee in employeeList)
            {
                LoadDataYearOneEmployee(employee, 1);
            }
            
            Axis.Labels = LabelMonth;
        }
        
        private void LoadDataYearOneEmployee(EmployeeModel employee, int type, string yearChoose = "2021")
        {
            // reset data
            var leaderMonths = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var deputyMonths = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            //total = 0;

            foreach (var tourGroup in tourGroupList)
            {
                var month = tourGroup.StartDate.Value.Month;
                var year = tourGroup.StartDate.Value.Year;
                
                // customerList not null and year choose = year
                if (year == int.Parse(yearChoose))
                {
                    if(employee.Id == tourGroup.TourLeaderId) leaderMonths[month - 1]++;
                    if(employee.Id == tourGroup.TourDeputyId) deputyMonths[month - 1]++;
                }
                //total++;
            }
            
            if (type == 1)
            {
                DrawChartAllEmployee(leaderMonths, deputyMonths, employee.Name);
                UpdateInfoAllTour(yearChoose);
            }
            else
            {
                DrawCharYearOneEmployee(leaderMonths, deputyMonths);
                UpdateInfoOneEmployee(leaderMonths, deputyMonths);
            }
        }
        
        private void LoadDataMonthOneEmployee(EmployeeModel employee, string yearChoose = "2021", string monthChoose = "")
        {
            // reset data
            var leaderDay = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var deputyDay = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var quantity = 0;

            foreach (var tourGroup in tourGroupList)
            {
                var year = tourGroup.StartDate.Value.Year;
                var month = tourGroup.StartDate.Value.Month;
                var day = tourGroup.StartDate.Value.Day;
                
                if (month == int.Parse(monthChoose) && year == int.Parse(yearChoose))
                {
                    if(employee.Id == tourGroup.TourLeaderId) leaderDay[day - 1]++;
                    if(employee.Id == tourGroup.TourDeputyId) deputyDay[day - 1]++;
                }
                quantity++;
            }
            
            DrawCharMonthOneEmployee(leaderDay, deputyDay);
            UpdateInfoOneEmployee(leaderDay, deputyDay);
        }
        
        private void DrawCharYearOneEmployee(int[] arrLeader, int[] arrDeputy)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Leader",
                    Values = new ChartValues<double> { arrLeader[0], arrLeader[1], arrLeader[2], arrLeader[3], arrLeader[4], arrLeader[5], arrLeader[6], arrLeader[7], arrLeader[8], arrLeader[9], arrLeader[10], arrLeader[11] },
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
                    Title = "Deputy",
                    Values = new ChartValues<double> { arrDeputy[0], arrDeputy[1], arrDeputy[2], arrDeputy[3], arrDeputy[4], arrDeputy[5], arrDeputy[6], arrDeputy[7], arrDeputy[8], arrDeputy[9], arrDeputy[10], arrDeputy[11] },
                    Stroke = Brushes.IndianRed,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.IndianRed,
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
        
        private void DrawCharMonthOneEmployee(int[] arrLeader, int[] arrDeputy)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double>
                    {
                        arrLeader[0], arrLeader[1], arrLeader[2], arrLeader[3], arrLeader[4], 
                        arrLeader[5], arrLeader[6], arrLeader[7], arrLeader[8], arrLeader[9], 
                        arrLeader[10], arrLeader[11], arrLeader[12], arrLeader[13], arrLeader[14], 
                        arrLeader[15], arrLeader[16], arrLeader[17], arrLeader[18], arrLeader[19], 
                        arrLeader[20], arrLeader[21], arrLeader[22], arrLeader[23], arrLeader[24], 
                        arrLeader[25], arrLeader[26], arrLeader[27], arrLeader[28], arrLeader[29], 
                        arrLeader[30]
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
                        arrDeputy[0], arrDeputy[1], arrDeputy[2], arrDeputy[3], arrDeputy[4], 
                        arrDeputy[5], arrDeputy[6], arrDeputy[7], arrDeputy[8], arrDeputy[9], 
                        arrDeputy[10], arrDeputy[11], arrDeputy[12], arrDeputy[13], arrDeputy[14], 
                        arrDeputy[15], arrDeputy[16], arrDeputy[17], arrDeputy[18], arrDeputy[19], 
                        arrDeputy[20], arrDeputy[21], arrDeputy[22], arrDeputy[23], arrDeputy[24], 
                        arrDeputy[25], arrDeputy[26], arrDeputy[27], arrDeputy[28], arrDeputy[29], 
                        arrDeputy[30]
                    },
                    Stroke = Brushes.IndianRed,
                    Fill = new SolidColorBrush
                    {
                        Color = Colors.IndianRed,
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
        
        private void DrawChartAllEmployee(int[] arrLeader, int[] arrDeputy, string name)
        {
            // join 2 array
            var arrTotal = new int[12];
            for (var i = 0; i < 12; i++)
            {
                arrTotal[i] = arrLeader[i] + arrDeputy[i];
            }
            
            if(colorIndex == ColorData.ColorCodes.Length - 1) colorIndex = 0;
            Brush stroke = (SolidColorBrush)new BrushConverter().ConvertFrom(ColorData.ColorCodes[colorIndex++]);
            
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
                    arrTotal[0], arrTotal[1], arrTotal[2], arrTotal[3], arrTotal[4], arrTotal[5],
                    arrTotal[6], arrTotal[7], arrTotal[8], arrTotal[9], arrTotal[10], arrTotal[11]
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
        
        private void UpdateInfoOneEmployee(int[] arrLeader, int[] arrDeputy)
        {
            int leader = 0;
            int deputy = 0;
            
            for (int i = 0; i < 12; i++)
            {
                if (arrLeader[i] != 0) leader++;
                if (arrDeputy[i] != 0) deputy++;
            }
            
            LbTourGuide.Content = leader.ToString("N0");
            LbTourDeputy.Content = deputy.ToString("N0");
            LbTotal.Content = (leader + deputy).ToString("N0");
        }
        
        private void UpdateInfoAllTour(string year)
        {
            var total = tourGroupList.Count(tourGroup => tourGroup.StartDate.Value.Year == int.Parse(year));

            LbTourGuide.Content = total.ToString("N0");
            LbTourDeputy.Content = total.ToString("N0");
            LbTotal.Content = (total * 2).ToString("N0");
        }

        private void CbEmployee_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbEmployee.SelectedIndex == 0)
            {
                LoadDataAllEmployee();
                CbYear.SelectedIndex = 0;
                CbMonth.SelectedIndex = -1;
            }
            else
            {
                var id = CbEmployee.SelectedItem.ToString().Split('-')[0];
                var employee = new EmployeeModel();
                
                foreach (var item in employeeList.Where(item => item.Id == id))
                {
                    employee = item;
                }
                
                LoadDataYearOneEmployee(employee, 2);
                CbYear.SelectedIndex = 0;
                CbMonth.SelectedIndex = -1;
            }
        }

        private void CbYear_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbEmployee.SelectedIndex == 0)
                return;
            
            var id = CbEmployee.SelectedItem.ToString().Split('-')[0];
            var employee = new EmployeeModel();
                
            foreach (var item in employeeList.Where(item => item.Id == id))
            {
                employee = item;
            }
            
            LoadDataYearOneEmployee(employee, 2, CbYear.SelectedItem.ToString());
            CbMonth.SelectedIndex = -1;
        }

        private void CbMonth_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbMonth.SelectedIndex == -1 || CbEmployee.SelectedIndex == 0) return;
            
            var id = CbEmployee.SelectedItem.ToString().Split('-')[0];
            var employee = new EmployeeModel();
                
            foreach (var item in employeeList.Where(item => item.Id == id))
            {
                employee = item;
            }
            
            LoadDataMonthOneEmployee(employee, CbYear.SelectedItem.ToString(), CbMonth.SelectedItem.ToString());
        }
    }
}