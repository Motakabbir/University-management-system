using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public int Save(Department department)
        {
            if (department.Name!=null && department.Code!=null)
            {
                if (IsCodeExist(department.Code))
                {
                    throw new Exception("Department Code already exist");
                }
                else if (IsNameExist(department.Name))
                {
                    throw new Exception("Department Name already exist");
                }
                return departmentGateway.Save(department); 
            }
            else
            {
                throw new Exception("Please Provide Department Name and Department Code");
            }
           
        }

        public bool IsCodeExist(string code)
        {
            return departmentGateway.IsCodeExist(code);
        }
        public bool IsNameExist(string name)
        {
            return departmentGateway.IsNameExist(name);
        }
        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }
    }
}