namespace DTO
{
    public class CustomerModel
    {
        private string _id;
        private string _avatar;
        private string _name;
        private string _email;
        private string _phone;
        private string _address;

        public string Id
        {
            get => _id;
            set => _id = value;
        }
        
        public string Avatar
        {
            get => _avatar;
            set => _avatar = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public CustomerModel() { }

        public CustomerModel(string id, string avatar, string name, string email, string phone, string address)
        {
            _id = id;
            _avatar = avatar;
            _name = name;
            _email = email;
            _phone = phone;
            _address = address;
        }
    }
}