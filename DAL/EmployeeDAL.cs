using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using FireSharp;

namespace DAL
{
    public class EmployeeDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Employee");
            var data = result.ResultAs<List<EmployeeModel>>();

            return data;
        }
        
        public async Task<EmployeeModel> GetEmployeeById(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Employee/" + id);
            var data = result.ResultAs<EmployeeModel>();

            return data;
        }
        
        public async Task<bool> CheckDuplicate(EmployeeModel employee)
        {
            var employeeList = await GetAllEmployee();
            var result = false;
            
            if (employeeList != null)
            {
                if (employeeList.Any(item => item.Name == employee.Name))
                {
                    result = true;
                }
            }
            
            return result;
        }
    }
}