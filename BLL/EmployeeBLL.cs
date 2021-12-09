using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL _employeeDAL;
        
        public Task<List<EmployeeModel>> GetAllEmployee()
        {
            _employeeDAL = new EmployeeDAL();
            return _employeeDAL.GetAllEmployee();
        }
    }
}