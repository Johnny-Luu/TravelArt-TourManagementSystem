using System;
using System.Collections.Generic;
using DTO;

namespace Models
{
    public class TourModel
    {
        private string _id = "";
        private string _img = "";
        private string _name = "";
        private string _description = "";
        private string _price = "";
        private List<RatingModel> _ratingList = new List<RatingModel>();
        private int _status = 1;        // 0 - not available, 1 - available
        private string _destinationIds = "";

        public string Id
        {
            get => _id;
            set => _id = value;
        }
        
        public string Img
        {
            get => _img;
            set => _img = value;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        
        public string Price
        {
            get => _price;
            set => _price = value;
        }
        
        public List<RatingModel> RatingList
        {
            get => _ratingList;
            set => _ratingList = value;
        }


        public int Status
        {
            get => _status;
            set => _status = value;
        }

        public string DestinationIds
        {
            get => _destinationIds;
            set => _destinationIds = value;
        }


        public TourModel() { }

        public TourModel(string id, string img, string name, string description, string price, int status, string destinationIds)
        {
            _id = id;
            _img = img;
            _name = name;
            _description = description;
            _price = price;
            _status = status;
            _destinationIds = destinationIds;
        }
    }
}