using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
// Вызов процедур
namespace CsOracleTutorial
{
    class CallProcedureExample
    {
        static void Main(string[] args)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            { 
 
                OracleCommand cmd = new OracleCommand("Get_Employee_Info", conn);
 
                cmd.CommandType = CommandType.StoredProcedure;
 
                cmd.Parameters.Add("@p_Emp_Id", OracleDbType.Int32).Value =100;
 
                cmd.Parameters.Add(new OracleParameter("@v_Emp_No", OracleDbType.Varchar2, 20));
                cmd.Parameters.Add(new OracleParameter("@v_First_Name", OracleDbType.Varchar2, 50));
                cmd.Parameters.Add(new OracleParameter("@v_Last_Name", OracleDbType.Varchar2, 50));
                cmd.Parameters.Add(new OracleParameter("@v_Hire_Date", OracleDbType.Date)); 
 
                cmd.Parameters["@v_Emp_No"].Direction = ParameterDirection.Output;
                cmd.Parameters["@v_First_Name"].Direction = ParameterDirection.Output;
                cmd.Parameters["@v_Last_Name"].Direction = ParameterDirection.Output;
                cmd.Parameters["@v_Hire_Date"].Direction = ParameterDirection.Output;
  
                cmd.ExecuteNonQuery();
 
                string empNo = cmd.Parameters["@v_Emp_No"].Value.ToString();
                string firstName = cmd.Parameters["@v_First_Name"].Value.ToString();
                string lastName = cmd.Parameters["@v_Last_Name"].Value.ToString();
                object hireDateObj =  cmd.Parameters["@v_Hire_Date"].Value;
 
                Console.WriteLine("hireDateObj type: "+ hireDateObj.GetType().ToString());
                OracleDate hireDate = (OracleDate)hireDateObj;
 
 
                Console.WriteLine("Emp No: " + empNo);
                Console.WriteLine("First Name: " + firstName);
                Console.WriteLine("Last Name: " + lastName);
                Console.WriteLine("Hire Date: " + hireDate);
 
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
    }
 
 
}


