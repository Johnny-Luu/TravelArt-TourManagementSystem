using System;

namespace Models
{
    public class TourModel
    {
        private string _id;
        private string _name;
        private string _description;
        private int _currentComment;
        private int _currentTour;
        private double _rating;
        private int _status;        // 0 - not available, 1 - available
        
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
        
        public string Description
        {
            get => _description;
            set => _description = value;
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

        public TourModel(string id ,string name, string description, int currentComment, int currentTour, double rating, int status)
        {
            _id = id;
            _name = name;
            _description = description;
            _currentComment = currentComment;
            _currentTour = currentTour;
            _rating = rating;
            _status = status;
        }
    }
}