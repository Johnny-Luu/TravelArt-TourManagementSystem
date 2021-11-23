using System;

namespace Models
{
    public class TourModel
    {
        private string _id = "";
        private string _img = "";
        private string _name = "";
        private string _description = "";
        private string _price = "";
        private int _currentComment = 0;
        private int _currentTour = 0;
        private double _rating = 0;
        private int _status = 1;        // 0 - not available, 1 - available
        
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
        
        public int CurrentComment
        {
            get => _currentComment;
            set => _currentComment = value;
        }

        public int CurrentTour
        {
            get => _currentTour;
            set => _currentTour = value;
        }

        public double Rating
        {
            get => _rating;
            set => _rating = value;
        }

        public int Status
        {
            get => _status;
            set => _status = value;
        }

        public TourModel() { }

        public TourModel(string id, string img ,string name, string description, string price, int currentComment, int currentTour, double rating, int status)
        {
            _id = id;
            _img = img;
            _name = name;
            _description = description;
            _price = price;
            _currentComment = currentComment;
            _currentTour = currentTour;
            _rating = rating;
            _status = status;
        }
    }
}