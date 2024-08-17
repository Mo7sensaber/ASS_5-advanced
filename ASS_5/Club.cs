using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_5
{
    internal class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        private List<Employee> Members = new List<Employee>();

        public void AddMember(Employee E)
        {
            if (E != null)
            {
                Members.Add(E);
                E.EmployeeLayOff += RemoveMember;
            }
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                if (e.Cause == LayOffCause.VacationStockLessThanZero)
                {
                    Members.Remove(employee);
                    Console.WriteLine($"Employee with ID {employee.EmployeeID} was removed from the club due to: {e.Cause}");
                }
                else
                {
                    Console.WriteLine($"Employee with ID {employee.EmployeeID} was not removed from the club due to: {e.Cause}");
                }
            }
        }
    }
}
