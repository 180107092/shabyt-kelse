using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Tutorial.SqlConn;
using System.Data;
 
namespace CsOracleTutorial
{
    class UpdateExample
    {
        static void Main(string[] args)
        {
           
            OracleConnection conn  = DBUtils.GetDBConnection();
            conn.Open();
            try
            { 
                string sql = "Update Employee set Salary = @salary where Emp_Id = @empId";
  
                OracleCommand cmd = new OracleCommand();
  
                cmd.Connection = conn; 
                cmd.CommandText = sql;
 
          
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = 850;
                cmd.Parameters.Add("@empId", SqlDbType.Decimal).Value = 7369; 
 
                int rowCount = cmd.ExecuteNonQuery();
 
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            { 
                conn.Close(); 
                conn.Dispose();
                conn = null;
            }
 
 
            Console.Read();
 
        }
    }
 
}




