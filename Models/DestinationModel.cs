namespace DTO
{
    public class DestinationModel
    {
        private string _id = "";
        private string _img = "";
        private string _name = "";
        private string _description = "";
        private string _idHotel = "";

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
        
        public string IdHotel
        {
            get => _idHotel;
            set => _idHotel = value;
        }

        public DestinationModel() {}

        public DestinationModel(string id, string img, string name, string description, string idHotel)
        {
            _id = id;
            _img = img;
            _name = name;
            _description = description;
            _idHotel = idHotel;
        }
    }
}