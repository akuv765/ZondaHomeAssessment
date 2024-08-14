using AssessmentAmit.Models;
using AssessmentAmit.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssessmentAmit.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x =>
              new SelectListItem()
              {
                  Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                  Value = x.ToString()
              }), "Value", "Text");

            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20).Select(x =>

                new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString()
                }), "Value", "Text");

            EmpRepository EmpRepo = new EmpRepository();
            List<Employee> employees = EmpRepo.GetAllEmployees();
            ViewBag.Employees = new SelectList(employees.Select(x =>

               new SelectListItem()
               {
                   Text = x.FirstName+" "+x.LastName.ToString(),
                   Value = x.Id.ToString()
               }), "Value", "Text");
            ViewBag.IsCalculated = false;
            return View(new Salary());
        }

        public ActionResult GetDays(int month, int year)
        {
            int days = DateTime.DaysInMonth(year, month);
            JsonResult result = Json(JsonConvert.SerializeObject(days), JsonRequestBehavior.AllowGet);
            return result;
        }

        [HttpPost]
        public ActionResult CalculateSalary(Salary salary)
        {
            EmpRepository EmpRepo = new EmpRepository();
            if (ModelState.IsValid)
            {
                Employee emp = EmpRepo.GetAllEmployees().Find(Emp => Emp.Id == salary.EmployeeId);
                decimal basic = Math.Round((emp.Basic / salary.TotalDays) * salary.PresentDays, 2);

                salary.Basic = basic;
                salary.HRA = (basic * 15) / 100;
                salary.DA = (basic * 10) / 100;
                salary.TA = emp.TA;
                salary.GrossSalary = salary.Basic + salary.HRA + salary.DA + salary.TA;
            }
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x =>
                  new SelectListItem()
                  {
                      Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                      Value = x.ToString(),
                      Selected = x.ToString() == salary.Month.ToString()
                  }), "Value", "Text");

            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20).Select(x =>

                new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                    Selected = x.ToString() == salary.Year.ToString()
                }), "Value", "Text");
            List<Employee> employees = EmpRepo.GetAllEmployees();
            ViewBag.Employees = new SelectList(employees.Select(x =>

               new SelectListItem()
               {
                   Text = x.FirstName + " " + x.LastName.ToString(),
                   Value = x.Id.ToString(),
                   Selected = x.Id.ToString() == salary.EmployeeId.ToString()
               }), "Value", "Text");

            ViewBag.IsCalculated = true;
            return View("Index", salary);
        }

    }
}