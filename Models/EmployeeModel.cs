namespace DTO
{
    public class EmployeeModel
    {
        private string _id;
        private string _name;
        
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public EmployeeModel() { }
        
        public EmployeeModel(string id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}