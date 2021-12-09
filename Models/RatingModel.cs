namespace DTO
{
    public class RatingModel
    {
        private string _customerId;
        private int _rating;
        private string _comment;
        private string _time;

        public string CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public int Rating
        {
            get => _rating;
            set => _rating = value;
        }

        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }

        public string Time
        {
            get => _time;
            set => _time = value;
        }

        public RatingModel() { }

        public RatingModel(string customerId, int rating, string comment, string time)
        {
            _customerId = customerId;
            _rating = rating;
            _comment = comment;
            _time = time;
        }
    }
}