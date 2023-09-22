using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAE;
using CAM;

namespace CRUDMVC.Controllers
{
    //Controlador que hereda de la clase Controller - es automatico en VS2022
    public class HomeController : Controller
    {       
        EmployeeManage employeeM = new EmployeeManage();

        public ActionResult Index()
        {
            return View();
        }

        //Listar
        public JsonResult GetAllEmployee()
        {
            return Json(employeeM.getAll(), JsonRequestBehavior.AllowGet);
        }

        //Listar Empleado by IDEmpleado, retorna la entidad que tiene el id
        public JsonResult GetEmplooyeByIDEmployee(int IDEmployee)
        {
            var Employee = employeeM.getAll().Find(x => x.IDEmpleados.Equals(IDEmployee));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        //Insertar
        public JsonResult InsertEmployee(EmployeeEntity employee)
        {
            return Json(employeeM.InsertEmployee(employee), JsonRequestBehavior.AllowGet);
        }

        //Actualizar
        public JsonResult UpdateEmployee(EmployeeEntity employee)
        {
            return Json(employeeM.UpdateEmployee(employee), JsonRequestBehavior.AllowGet);
        }

        //Eliminar
        public JsonResult DeleteEmployeeByIDEmployee(int IDEmployee)
        {
            return Json(employeeM.DeleteEmployee(IDEmployee), JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}