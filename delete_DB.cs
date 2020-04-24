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
    class DeleteExample
    {
        static void Main(string[] args)
        {
            OracleConnection conn  = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                
 
                string sql = "Delete from Salary_Grade where Grade = @grade ";
 
                OracleCommand cmd = new OracleCommand();
 
                cmd.Connection = conn;
 
                cmd.CommandText = sql; 
 
                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = 3;  
 
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







