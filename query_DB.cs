using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn; 
using System.Data.Common;
using Oracle.DataAccess.Client;
 
namespace CsOracleTutorial
{
    class QueryDataExample
    {
        static void Main(string[] args)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                QueryEmployee(conn);
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
            }       
            Console.Read();
        }
 
        private static void QueryEmployee(OracleConnection conn)
        { 
            string sql = "Select Emp_Id, Emp_No, Emp_Name, Mng_Id from Employee"; 
 
            OracleCommand cmd = new OracleCommand();
 
            cmd.Connection = conn;
            cmd.CommandText = sql; 
 
             
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                     
                    while (reader.Read())
                    {
                        int empIdIndex = reader.GetOrdinal("Emp_Id");                         
 
                        long empId =  Convert.ToInt64(reader.GetValue(0));
                         
                        // Индекс столбца Emp_No = 1.
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("Emp_Name");
                        string empName = reader.GetString(empNameIndex);
 
 
                        int mngIdIndex = reader.GetOrdinal("Mng_Id");
 
                        long? mngId = null;
  
                        if (!reader.IsDBNull(mngIdIndex))
                        {
                            mngId = Convert.ToInt64(reader.GetValue(mngIdIndex)); 
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + empIdIndex);
                        Console.WriteLine("EmpId:" + empId);
                        Console.WriteLine("EmpNo:" + empNo);
                        Console.WriteLine("EmpName:" + empName);
                        Console.WriteLine("MngId:" + mngId);
                    }
                }
            }
 
        }
    }
 
}

