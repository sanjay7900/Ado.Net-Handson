using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeDetails
{
    public class Employee
    {
        // Data Source = DESKTOP - AMR2CQS\MSSQLSERVER01;Initial Catalog = BankDb; Integrated Security = True
        public static string sqlConnectionString = @"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=BankDb;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
        public string InsertEmployee()
        {
            Console.WriteLine("Enter the Employee id ");
            int empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Employee Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Emplyee Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the Epmloyee Department");
            string department = Console.ReadLine();
            string Query = "insert into Employee values("+empid+",'"+name+"',"+age+",'"+address+"','"+department+"')";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();   
            cmd.ExecuteNonQuery();  
            sqlConnection.Close();  
            return "Employee inserted";
        }
        public string SelectEmployeeById(int id)
        {

            

            return "";
        }

        public string DeleteEmployee()
        {
            return "";
        }
        public string UpdateEmployee()
        {
            return "";
        }
        public string SelectEmployes()
        {
            return "";
        }

    }
}
