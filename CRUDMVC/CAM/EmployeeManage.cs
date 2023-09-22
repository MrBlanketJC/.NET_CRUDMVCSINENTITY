using CAD;
using CAE;
using System.Collections.Generic;

namespace CAM
{
    public class EmployeeManage
    {
        EmployeeData employeeD = new EmployeeData();

        //Listar
        public List<EmployeeEntity> getAll()
        {
            return employeeD.GetAll();
        }

        //Insertar
        public bool InsertEmployee(EmployeeEntity employee)
        {
            return employeeD.Insert(employee);
        }

        //Actulizar
        public bool UpdateEmployee(EmployeeEntity employee)
        {
            return employeeD.Update(employee);
        }

        //Eliminar
        public bool DeleteEmployee(int IDEmployee)
        {
            return employeeD.Delete(IDEmployee);
        }
    }
}
