using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using System.Data.SqlClient; //sql server rovider
using System.Data;

namespace EmployeeDALLib
{
    public class AdoConnected
    {
        SqlConnection con;
        SqlCommand cmd;
        public AdoConnected()
        {
            //Configure Connection String
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = DHAN31\SQLEXPRESS; Initial Catalog = JAB_DB; Integrated Security = True";
            ConfigurationManager.ConnectionString
        }

        public void InsertEmployee(Emplyoee emp)
        {

            
            //ToDo Insert Operation Using SQL

            cmd = new SqlCommand();
            cmd.CommandText = "Insert into tbl_employee values(@ec,@en,@sal,@did)";

            //Add parameters values to Command Text

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", emp.Ecode);
            cmd.Parameters.AddWithValue("@en", emp.Ename);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@did", emp.Deptid);

            //attach conection
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            //add things


        }

        public int DeleteEmp(int ecode)
        { 
            //ToDo Delete Statement using ADO.NET

            cmd = new SqlCommand();
            cmd.CommandText = "delete from tbl_employee where ecode=" + ecode;

            //attach
            cmd.Connection = con;

            //Open Connection
            con.Open();

            //Execute Stmnt
            cmd.ExecuteNonQuery();
            int rowsAffected = cmd.ExecuteNonQuery();
            
            con.Close();
            return rowsAffected;

        }

        public void UpdateEmpSalary(int ecode, int newsal)
        { 
            //ToDo Update Statement using ADO.NET

            cmd = new SqlCommand();
            cmd.CommandText = "update tbl_employee set salary="+ newsal +" where ecode = "+ ecode;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            


        }
        
        public List<Emplyoee> SelectAllEmp()
        {
            List<Emplyoee> empList = new List<Emplyoee>();
            //ToDo Select Statement using ADO.NET
            
            
            //Configure command for SELECT

            cmd = new SqlCommand();
            cmd.CommandText = "Select *from tbl_employee";
            cmd.Connection = con;

            //Open Connection
            con.Open();

            //Execute the command and get the database
            SqlDataReader sdr = cmd.ExecuteReader();

            //Read and input
            while (sdr.Read())
            {
                Emplyoee emp = new Emplyoee
                {
                    Ecode = (int)sdr[0],
                    Ename = sdr[1].ToString(),
                    Salary = (int)sdr[2],
                    Deptid = (int)sdr[3]
                };
                empList.Add(emp);
            }


            //Close the connection
            sdr.Close();
            con.Close();


            return empList;

        }

        public Emplyoee FindEmpById2(int ecode)
        {

            Emplyoee emp = new Emplyoee();


            cmd = new SqlCommand();
            cmd.CommandText = "Select * from tbl_employee where ecode = "+ ecode;
            cmd.Connection = con;

            //Open Connection
            con.Open();

            //Execute the command and get the database
            SqlDataReader sdr = cmd.ExecuteReader();

            //Read and input
            
                
                    emp.Ecode = (int)sdr[0];
                    emp.Ename = sdr[1].ToString();
                    emp.Salary = (int)sdr[2];
                    emp.Deptid = (int)sdr[3];
                
                
            


            //Close the connection
            sdr.Close();
            con.Close();


            return emp;

        }

        public void UpdateSalUsingSP(int ecode, int salary)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "sp_UpdateSlary";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ec", ecode);
            cmd.Parameters.AddWithValue("@sal", salary);

            cmd.Connection = con;


            con.Open();
            cmd.ExecuteNonQuery();

            
            con.Close();

        }

        public void DeleteAll()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "TRUNCATE TABLE tbl_employee";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
