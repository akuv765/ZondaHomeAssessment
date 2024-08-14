using AssessmentAmit.Models;
using AssessmentAmit.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssessmentAmit.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/GetAllEmpDetails
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }

        public ActionResult GetEmpDetailById(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            Employee emp = EmpRepo.GetAllEmployees().Find(Emp => Emp.Id == id);
            JsonResult result = Json(JsonConvert.SerializeObject(new { emp = emp }), JsonRequestBehavior.AllowGet);
            return result;
        }

        // GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View(new Employee());
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(Employee Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                    return RedirectToAction("GetAllEmpDetails");
                }
                else
                {
                    return View(Emp);
                }
            }
            catch
            {
                ViewBag.Message = "Error Occured!";
                return View(new Employee());
            }
            
        }

        // GET: Employee/EditEmpDetails/5
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            ViewBag.Mode = "Edit";
            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Id == id));
        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditEmpDetails(int id, Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();

                    EmpRepo.UpdateEmployee(emp);
                    return RedirectToAction("GetAllEmpDetails");
                }
                else
                {
                    return View(emp);
                }
            }
            catch
            {
                return View(emp);
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";
                }
                
            }
            catch(Exception ex)
            {
                //return View();
            }
            return RedirectToAction("GetAllEmpDetails");
        }
    }
}
