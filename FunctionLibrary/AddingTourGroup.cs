using System;
using System.Windows.Forms;

namespace FunctionLibrary
{
    public static class AddingTourGroup
    {
        public static bool isAddAble(string name,string tourId,string tourName,string tourLeaderId,string tourLeaderName,string tourDeputyId,string tourDeputyName,string slot,DateTime? startDate, DateTime? endDate)
        {
            if (name.Length<5)
            {
                MessageBox.Show("Please enter tour name longer or equal to 50 character ");
                return false;
            }
            
            if (name.Length>50)
            {
                MessageBox.Show("Please enter tour name shorter or equal to 50 character ");
                return false;
            }
            //check empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(tourLeaderId) ||
                string.IsNullOrEmpty(tourLeaderName) ||
                string.IsNullOrEmpty(tourDeputyId) || string.IsNullOrEmpty(tourDeputyName) ||
                string.IsNullOrEmpty(tourId) ||
                string.IsNullOrEmpty(tourName) || string.IsNullOrEmpty(slot) || startDate == null || endDate == null)
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }
            //check name
            
            //check type slot
            if (!int.TryParse(slot, out int slotNumber))
            {
                MessageBox.Show("Slot must be a number");
                return false;
            }

            if (slotNumber < 1)
            {
                MessageBox.Show("Slot must bigger than 0");
                return false;
            }
            
            //check tourLeader and Deputy the same
            if (tourLeaderId == tourDeputyId)
            {
                MessageBox.Show("Tour leader and tour deputy cannot be the same");
                return false;
            }
            //check startDate < endDate
            if(startDate > endDate)
            {
                MessageBox.Show("Start date must be less than end date");
                return false;
            }
            return true;
        }
    }
}