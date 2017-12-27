using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using EntitiesLib;

namespace EmployeeDALLib
{
    public class AdoDisconnected
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        public AdoDisconnected() {
            //Configure Connection String
            con = new SqlConnection();
            con.ConnectionString = "Data Source=BLRLCVEDANTA;Initial Catalog=ITCDB;Integrated Security=True";
            
            
            //Configure Data Adapter
            da = new SqlDataAdapter();
            cmd = new SqlCommand();

            cmd.CommandText = "SELECT * from tbl_employee";
            cmd.Connection = con;

            //Attach command with Data Adapter
            da.SelectCommand = cmd;

            //Configure Dataset
            ds = new DataSet();
            da.Fill(ds, "tbl_employee");


        }
        public void InsertEmployee(Emplyoee emp)
        {


            //Create a new record as per table in Dataset

            DataRow row = ds.Tables[0].NewRow();

            //Add values to the newly created row

            row[0] = emp.Ecode;
            row[1] = emp.Ename;
            row[2] = emp.Salary;
            row[3] = emp.Deptid;

            //Add the row to the Dataset
            ds.Tables[0].Rows.Add(row);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            //Save the Dataset
            da.Update(ds, "tbl_employee");
        }

        public int DeleteEmp(int ecode)
        {
            //Find the records to be delete
            DataRow[] rows = ds.Tables[0].Select("ecode= " + ecode);
            //Delete the rows

            if (rows.Count() == 0)
            {
                return 0;
            }
            
                foreach (DataRow row in rows)
                {
                    row.Delete();
                }
                //Update the DB
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                return da.Update(ds, "tbl_employee");
            
        }

        public void UpdateEmpSalary(int ecode, int newsal)
        {
            DataRow[] rows = ds.Tables[0].Select("ecode= " + ecode);

            //Check Availability
            if (rows.Count() == 0)
            {
                
            }
            //Update
            foreach (DataRow row in rows)
            {
                row[2] = newsal;
            }
             //Update the DB
             SqlCommandBuilder cb = new SqlCommandBuilder(da);
             da.Update(ds, "tbl_employee");
        }

        public List<Emplyoee> SelectAllEmp()
        {
            List<Emplyoee> empList = new List<Emplyoee>();
            //Add all the records from dataset
            foreach (DataRow row in ds.Tables[0].Rows){

               

                Emplyoee emp = new Emplyoee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };
                empList.Add(emp);
            }

            return empList;
        }

        public Emplyoee FindEmpById(int ecode)
        {

            Emplyoee emp = new Emplyoee();
            DataRow[] rows = ds.Tables[0].Select("ecode= " + ecode);
            
            DataRow row = rows[0];

            emp.Ecode = (int)row[0];
            emp.Ename = row[1].ToString();
            emp.Salary = (int)row[2];
            emp.Deptid = (int)row[3];

                
            
            return emp;

        }




    }
}
