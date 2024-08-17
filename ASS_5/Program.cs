namespace ASS_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesPerson salesPerson = new SalesPerson
            {
                EmployeeID = 1,
                BirthDate = new DateTime(1985, 5, 20),
                AchievedTarget = 80 
            };

            salesPerson.EmployeeLayOff += OnEmployeeLayOff;

            salesPerson.EndOfYearOperation();

            BoardMember boardMember = new BoardMember
            {
                EmployeeID = 2,
                BirthDate = new DateTime(1950, 10, 10)
            };

            boardMember.EmployeeLayOff += OnEmployeeLayOff;

            boardMember.EndOfYearOperation();

            boardMember.Resign();
        }

        static void OnEmployeeLayOff(object sender, EmployeeLayOffEventArgs e)
        {
            Employee employee = sender as Employee;
            Console.WriteLine($"Employee with ID {employee.EmployeeID} has been laid off due to: {e.Cause}");
        }
    }
}
    