using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using EmployeeDALLib;



namespace EmpBusinessLayer
{
    public class BLL
    {

        AdoDisconnected dalCon2;
        AdoConnected dalCon;
        


        public BLL()
        //{
        { 
        //    dalCon2 = new AdoDisconnected();  
            dalCon = new AdoConnected();  

        }
        public List<Emplyoee> GetAllEmps()
        {
            List<Emplyoee> empList = dalCon.SelectAllEmp();
            return empList;
        }

        public void AddEmployee(Emplyoee emp)
        {
            dalCon.InsertEmployee(emp);
        }

        public int RemoveEmployee(int ecode)
        {
            return dalCon.DeleteEmp(ecode);
        }

        public void ModifySal(int ec, int sal)
        {
            dalCon.UpdateEmpSalary(ec, sal);
        }

        //public Emplyoee MyDesiredId(int ec)
        //{
        //    return dalCon.FindEmpById(ec);
        //}

        //public void CallSP(int ecode, int salary)
        //{
        //    dalCon2.UpdateSalUsingSP(ecode, salary);
        //}
        public void TruncateTable()
        {
            //dalCon..DeleteAll();
        }
    }
}
