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
            string sql = "select * from Employee where EmpId=" + id;
            sqlConnection.Open();
            SqlCommand cmd =new SqlCommand(sql, sqlConnection);
            DataTable dt =new DataTable();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            dt.Load(sqlDataReader);
            sqlConnection.Close();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                for(int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j]+" ") ;
                }
            }



            

            return "";
        }

        public string DeleteEmployee(int empid)
        {
            string deleteQuery = "delete from Employee where EmpId="+empid;
            SqlCommand cmd = new SqlCommand(deleteQuery, sqlConnection);
            sqlConnection.Open();
           int status= cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (status == 0)
            {
                return "Not Deteted";
            }
            return " Deleted";
        }
        public string UpdateEmployee( string changeName,int EmpId)
        {
            string sql = "update  Employee set EmpName='"+changeName+"' Where EmpId="+EmpId+"";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close ();
            if(status == 0)
            {
                return "Not Updated";
            }
            return "Updated";
        }
        public DataTable SelectEmployes()
        {
            string sql = "select * from Employee";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            sqlConnection.Close();
            return table;
            
        }

    }
}
