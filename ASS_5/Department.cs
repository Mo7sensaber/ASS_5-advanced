using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_5
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        private List<Employee> Staff = new List<Employee>();

        public void AddStaff(Employee E)
        {
            if (E != null)
            {
                Staff.Add(E);

                E.EmployeeLayOff += RemoveStaff;
            }
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                Staff.Remove(employee);
                Console.WriteLine($"Employee with ID {employee.EmployeeID} was removed from the department due to: {e.Cause}");
            }
        }
    }
}
