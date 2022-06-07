using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee=new Employee();
            Account account=new Account();
            string status=employee.InsertEmployee();
            Console.WriteLine(status);
            status=account.InsertAccount();
            Console.WriteLine(status);

            Console.ReadLine();
        }
    }
}
