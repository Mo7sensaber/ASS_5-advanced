using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_5
{
    public class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public bool CheckTarget(int Quota)
        {
            return AchievedTarget >= Quota;
        }

        public override void EndOfYearOperation()
        {
            int Quota = 100; 
            if (!CheckTarget(Quota))
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.FailedToAchieveSalesTarget
                });
            }
        }

        public override int VacationStock
        {
            get { return 0; }  
            set {  }
        }
    }

    public class BoardMember : Employee
    {
        public override int VacationStock
        {
            get { return 0; }  
            set {  }
        }

        public override void EndOfYearOperation()
        {
        }

        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs
            {
                Cause = LayOffCause.Resigned
            });
        }
    }
}
