using System;

namespace DTO
{
    public class RequestModel
    {
        private string _id;
        private string _customerId;
        private string _tourGroupId;
        private DateTime _date;
        private string _time;

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public string TourGroupId
        {
            get => _tourGroupId;
            set => _tourGroupId = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public string Time
        {
            get => _time;
            set => _time = value;
        }

        public RequestModel() { }
        
        public RequestModel(string id, string customerId, string tourGroupId, DateTime date, string time)
        {
            _id = id;
            _customerId = customerId;
            _tourGroupId = tourGroupId;
            _date = date;
            _time = time;
        }
    }
}