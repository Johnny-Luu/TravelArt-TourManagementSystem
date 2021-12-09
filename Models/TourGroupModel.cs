using System;

namespace DTO
{
    public class TourGroupModel
    {
        private string _id;
        private string _name;
        private string _tourLeaderId;
        private string _tourLeaderName;
        private string _tourDeputyId;
        private string _tourDeputyName;
        private string _tourId;
        private string _tourName;
        private int _slot;
        private DateTime? _startDate;    
        private DateTime? _endDate;

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string TourLeaderId
        {
            get => _tourLeaderId;
            set => _tourLeaderId = value;
        }

        public string TourLeaderName
        {
            get => _tourLeaderName;
            set => _tourLeaderName = value;
        }

        public string TourDeputyId
        {
            get => _tourDeputyId;
            set => _tourDeputyId = value;
        }

        public string TourDeputyName
        {
            get => _tourDeputyName;
            set => _tourDeputyName = value;
        }

        public string TourId
        {
            get => _tourId;
            set => _tourId = value;
        }

        public string TourName
        {
            get => _tourName;
            set => _tourName = value;
        }

        public int Slot
        {
            get => _slot;
            set => _slot = value;
        }

        public DateTime? StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set => _endDate = value; 
        }

        public TourGroupModel()
        {
        }

        public TourGroupModel(string id, string name, string tourLeaderId, string tourLeaderName, string tourDeputyId, string tourDeputyName, string tourId, string tourName, int slot, DateTime startDate, DateTime endDate)
        {
            _id = id;
            _name = name;
            _tourLeaderId = tourLeaderId;
            _tourLeaderName = tourLeaderName;
            _tourDeputyId = tourDeputyId;
            _tourDeputyName = tourDeputyName;
            _tourId = tourId;
            _tourName = tourName;
            _slot = slot;
            _startDate = startDate;
            _endDate = endDate; 
        }
    }
}