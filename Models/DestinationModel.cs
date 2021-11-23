namespace DTO
{
    public class DestinationModel
    {
        private string _id = "";
        private string _img = "";
        private string _name = "";
        private string _description = "";

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
        
        public DestinationModel() {}

        public DestinationModel(string id, string img, string name, string description)
        {
            _id = id;
            _img = img;
            _name = name;
            _description = description;
        }
    }
}