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
            string Query = "insert into Account values(" + accid + ",'" + name + "'," + age + ",'"+ address+"')";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return "Account Inserted";
        }
        public string SelectAccountById(int id)
        {
            string sql = "select * from Account where AccId=" + id;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            dt.Load(sqlDataReader);
            sqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + " ");
                }
            }





            return "";
        }

        public string DeleteAccount(int empid)
        {
            string deleteQuery = "delete from Account where EmpId=" + empid;
            SqlCommand cmd = new SqlCommand(deleteQuery, sqlConnection);
            sqlConnection.Open();
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (status == 0)
            {
                return "Not Deteted";
            }
            return " Deleted";
        }
        public string UpdateAccount(string changeName,int EmpId)
        {
            string sql = "update  Account set AccHolderName='" + changeName +"' Where AccId=" + EmpId + "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (status == 0)
            {
                return "Not Updated";
            }
            return "Updated";
        }
        public DataTable SelectAccounts()
        {
            string sql = "select * from Account";
            sqlConnection.Open();
            SqlCommand cmd =new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            sqlConnection.Close();
            return table;
        }

    }
}
