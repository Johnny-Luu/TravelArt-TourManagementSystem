using System;

namespace GUI.Models
{
    public class TourModel
    {
        private String _name;
        private String _description;
        private int _currentComment;
        private int _currentTour;
        private double _rating;
        private int _status;        // 0 - not available, 1 - available

        public String Name
        {
            get => _name;
            set => _name = value;
        }
        
        public String Description
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

        public TourModel(String name, String description)
        {
            _name = name;
            _description = description;
        }
    }
}