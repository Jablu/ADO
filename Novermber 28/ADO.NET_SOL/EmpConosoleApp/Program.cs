using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLib; //For Entities
using EmpBusinessLayer; //for BLL


namespace EmpConosoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            BLL bll = new BLL();


            //Add Record

            //Emplyoee emp = new Emplyoee();
            //Console.Write("Enter Ecode:");
            //emp.Ecode = int.Parse(Console.ReadLine());

            //Console.Write("Enter Ename:");
            //emp.Ename = Console.ReadLine();


            //Console.Write("Enter Salary:");
            //emp.Salary = int.Parse(Console.ReadLine());


            //Console.Write("Enter Department:");
            //emp.Deptid = int.Parse(Console.ReadLine());

            ////Use BLL to Add
            //bll.AddEmployee(emp);
            //Console.WriteLine("Record Inserted");

            //SHOW ALL EMP
            List<Emplyoee> empList = bll.GetAllEmps();
            foreach (var r in empList)
            {
             Console.WriteLine(r.Ecode + "\t" + r.Ename + "\t" + r.Salary + "\t" + r.Deptid + "\t");
            }
            Console.ReadLine();


            ////Delete Employee

            //Console.Write("Enter Ecode:");
            //int ecode = int.Parse(Console.ReadLine());
            //bll.RemoveEmployee(ecode);
            //if (bll.RemoveEmployee(ecode) == 0)
            //{
            //    Console.WriteLine("Invalid Employee");
            //}
            //else {

            //    Console.WriteLine("Record Deleted");
            //}



            ////SHOW ALL EMP
            //empList = bll.GetAllEmps();
            //foreach (var r in empList)
            //{
            //    Console.WriteLine(r.Ecode + "\t" + r.Ename + "\t" + r.Salary + "\t" + r.Deptid + "\t");
            //}
            //Console.ReadLine();


            //Modify

            //Console.Write("Enter Ecode:");
            //int upt_ec = int.Parse(Console.ReadLine());

            //Console.Write("Enter Salary:");
            //int upt_sal = int.Parse(Console.ReadLine());


            //Using SP
            //bll.CallSP(upt_ec, upt_sal);


            //bll.ModifySal(upt_ec, upt_sal);

            ////Console.WriteLine("Record Deleted");
            //SHOW ALL EMP
            //empList = bll.GetAllEmps();
            //foreach (var r in empList)
            //{
            //    Console.WriteLine(r.Ecode + "\t" + r.Ename + "\t" + r.Salary + "\t" + r.Deptid + "\t");
            //}
            //Console.ReadLine();

            ////Find My Employee
            //Console.Write("Enter Desired Ecode:");
            //int find_ec = int.Parse(Console.ReadLine());
            //Emplyoee emp = bll.MyDesiredId(find_ec);
            //Console.WriteLine(emp.Ecode + "\t" + emp.Ename + "\t" + emp.Salary + "\t" + emp.Deptid + "\t");
           
        }
    }
}
