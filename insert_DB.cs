using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common; 
using System.Data;
using Oracle.DataAccess.Client;
 
namespace CsOracleTutorial
{
    class InsertDataExample
    {
          static void Main(string[] args) 
          {
   
            OracleConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {    
                string sql = "Insert into Salary_Grade (Grade, High_Salary, Low_Salary) "
                                                 + " values (@grade, @highSalary, @lowSalary) "; 
 
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;  
 
                OracleParameter gradeParam = new OracleParameter("@grade",SqlDbType.Int);
                gradeParam.Value = 3;
                cmd.Parameters.Add(gradeParam);
 
                OracleParameter highSalaryParam = cmd.Parameters.Add("@highSalary", SqlDbType.Float);
                highSalaryParam.Value = 20000;
 
                cmd.Parameters.Add("@lowSalary", SqlDbType.Float ).Value = 10000; 
 
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
                connection.Close(); 
                connection.Dispose();
                connection = null;
            }
            
 
            Console.Read();
   
         }
    }
 
}