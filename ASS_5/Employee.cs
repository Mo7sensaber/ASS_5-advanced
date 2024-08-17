using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_5
{

    public enum LayOffCause
    {
        VacationStockLessThanZero,
        AgeGreaterThanSixty,
        FailedToAchieveSalesTarget, 
        Resigned                    

    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }

    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }

        private int vacationStock;

        public virtual int VacationStock
        {
            get { return vacationStock; }
            set { vacationStock = value; }
        }

        public virtual void EndOfYearOperation()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateTime.Now.AddYears(-age))
                age--;

            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.VacationStockLessThanZero
                });
            }
            else if (age > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.AgeGreaterThanSixty
                });
            }
        }
    }

}
