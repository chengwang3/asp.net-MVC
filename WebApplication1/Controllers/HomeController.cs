using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {    public class EmployeeBusinessLayer
        {
            public List<Employee> GetEmployees()
            {
                List<Employee> employees = new List<Employee>();
                Employee emp = new Employee();
                emp.Firstname = "cheng";
                emp.Lastname = "wang";
                emp.Salary = 5000;
                employees.Add(emp);

                emp = new Employee();
                emp.Firstname = "ming";
                emp.Lastname = "wang";
                emp.Salary = 8000;
                employees.Add(emp);

                emp = new Employee();
                emp.Firstname = "jie";
                emp.Lastname = "wang";
                emp.Salary = 4000;
                employees.Add(emp);

                emp = new Employee();
                emp.Firstname = "bao";
                emp.Lastname = "wang";
                emp.Salary = 6000;
                employees.Add(emp);

                return employees;

            }
        }
        public ActionResult GetIndex()
        {
            EmployeeListViewModel employeelistViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer employeebu = new EmployeeBusinessLayer();
            List<EmployeeViewModel> empList = new List<EmployeeViewModel>();
            List<Employee> employeelist = employeebu.GetEmployees();
            foreach (Employee em in employeelist)
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                emp.EmployeeName = em.Firstname + em.Lastname;
                if (em.Salary > 5000)
                { emp.SalaryColor = "green"; }
                else
                {
                    emp.SalaryColor = "yellow";
                }
                emp.Salary = em.Salary.ToString("C");
                empList.Add(emp);
            }
            employeelistViewModel.Employees = empList;
            employeelistViewModel.UserName = "admin";

            return View("Index", employeelistViewModel);
        }

    }
}