namespace DTO
{
    public class HotelModel
    {
        private string _id = "";
        private string _name = "";
        private string _price = "";
        private string _address = "";
        private string _phoneNumber = "";

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

        public string Price
        {
            get => _price;
            set => _price = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        
        public HotelModel()
        {
        }

        public HotelModel(string id, string name, string price, string address, string phoneNumber)
        {
            _id = id;
            _name = name;
            _price = price;
            _address = address;
            _phoneNumber = phoneNumber;
        }
    }
}