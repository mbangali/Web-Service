using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BO;
namespace WebApplication4
{
    /// <summary>
    /// Summary description for CRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CRUD : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertEmployee(Employee obj)
        {
            return obj.Insert();
        }
        [WebMethod]
        public bool UpdateEmployee(Employee obj)
        {
            return obj.Update();
        }
        [WebMethod]
        public bool DeleteEmployee(Employee obj)
        {
            return obj.Delete();
        }
        [WebMethod]
        public Employee GetEmployee(int id)
        {
            Employee obj = new Employee();
            return obj.Get(id);
        }
     
        [WebMethod]
        public List<Employee> GetAllEmployee()
        {
            Employee obj = new Employee();
            return obj.GetAll();
        }
    }
}
