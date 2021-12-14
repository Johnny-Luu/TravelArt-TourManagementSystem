using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BLL;
using DTO;
using FunctionLibrary;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class AddingTourGroupViewModel
    {
        private List<EmployeeModel> _employeeList;
        
        public PageAddingTourGroup PgAddingTourGroup { get; set; }

        public ICommand LoadDataCommand { get; set; }
        public ICommand PushTourGroupCommand { get; set; }

        public AddingTourGroupViewModel()
        {
            LoadDataCommand = new RelayCommand<PageAddingTourGroup>(para => true, para => LoadData(para));
            PushTourGroupCommand = new RelayCommand<PageAddingTourGroup>(para => true, para => PushTourGroup(para));
        }

        public async void LoadData(PageAddingTourGroup para)
        {
            PgAddingTourGroup = para;

            // load employee data
            var employeeBLL = new EmployeeBLL();
            _employeeList = await employeeBLL.GetAllEmployee();
            foreach (var item in _employeeList)
            {
                PgAddingTourGroup.CbTourLeader.Items.Add(item.Id + "-" + item.Name);
                PgAddingTourGroup.CbTourDeputy.Items.Add(item.Id + "-" + item.Name);
            }
            
            // load tour data
            var tourBLL = new TourBLL();
            var tourList = await tourBLL.GetAllTour();
            foreach (var item in tourList)
            {
                PgAddingTourGroup.CbTour.Items.Add(item.Id + "-" + item.Name);
            }
        }

        public async void PushTourGroup(PageAddingTourGroup para)
        {
            PgAddingTourGroup = para;
            
            // get generated id
            var tourGroupBLL = new TourGroupBLL();
            var id = await tourGroupBLL.InitID();

            var name = PgAddingTourGroup.TbTourGroupName.Text;
            var tourLeaderId = "";
            var tourLeaderName = "";
            var tourDeputyId = "";
            var tourDeputyName = "";
            var tourId = "";
            var tourName = "";
            var slot = PgAddingTourGroup.TbSlot.Text;
            DateTime? startDate = PgAddingTourGroup.DpStartDate.SelectedDate;
            DateTime? endDate = PgAddingTourGroup.DpEndDate.SelectedDate;

            if (PgAddingTourGroup.CbTourLeader.SelectedItem != null)
            {
                tourLeaderId = PgAddingTourGroup.CbTourLeader.SelectedItem.ToString().Split('-')[0];
                tourLeaderName = PgAddingTourGroup.CbTourLeader.SelectedItem.ToString().Split('-')[1];
            }
            
            if (PgAddingTourGroup.CbTourDeputy.SelectedItem != null)
            {
                tourDeputyId = PgAddingTourGroup.CbTourDeputy.SelectedItem.ToString().Split('-')[0];
                tourDeputyName = PgAddingTourGroup.CbTourDeputy.SelectedItem.ToString().Split('-')[1];
            }
            
            if (PgAddingTourGroup.CbTour.SelectedItem != null)
            {
                tourId = PgAddingTourGroup.CbTour.SelectedItem.ToString().Split('-')[0];
                tourName = PgAddingTourGroup.CbTour.SelectedItem.ToString().Split('-')[1];
            }

          if(! AddingTourGroup.isAddAble(name, tourId, tourName, tourLeaderId, tourLeaderName, tourDeputyId,
                tourDeputyName, slot, startDate, endDate)) return;

          int.TryParse(slot, out int slotNumber);
          
            
            var tourGroup = new TourGroupModel
            {
                Id = id,
                Name = name,
                TourLeaderId = tourLeaderId,
                TourLeaderName = tourLeaderName,
                TourDeputyId = tourDeputyId,
                TourDeputyName = tourDeputyName,
                TourId = tourId,
                TourName = tourName,
                Slot = slotNumber,
                StartDate = startDate,
                EndDate = endDate,
                CustomerList = ""
            };
            
            tourGroupBLL.PushTourGroup(tourGroup);
            MessageBox.Show("Successfully added");
        }
    }
}