using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeDetails
{
    public class Account
    {
        // Data Source = DESKTOP - AMR2CQS\MSSQLSERVER01;Initial Catalog = BankDb; Integrated Security = True
        public static string sqlConnectionString = @"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=BankDb;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
        public string InsertAccount()
        {
            Console.WriteLine("Enter the Account");
            int accid =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Account holder name");
            string  name =Console.ReadLine();
            Console.WriteLine("Enter the Account holder  Age");
            int age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Account Holder Address");
            string address =Console.ReadLine();
            string Query = "insert into Employee values(" + accid + ",'" + name + "'," + age + ",'" + address+"')";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return "Account Inserted";
        }
        public string SelectAccountById(int id)
        {
            return "";
        }

        public string DeleteAccount()
        {
            return "";
        }
        public string UpdateAccount()
        {
            return "";
        }
        public string SelectAccounts()
        {
            return "";
        }

    }
}
