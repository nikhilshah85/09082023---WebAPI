using employeeManagement_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employee eObj = new Employee(); //this is not a good practice, we should use DI instead of this

        #region Http Get Methods
        [HttpGet]
        [Route("/employee/list")]
        public IActionResult GetAllEmployees()
        {
            //we are suppose to return HttpStatus Code and HttpBody/content

            var emp = eObj.GetAllEmployees();
            return Ok(emp);
        }
        [HttpGet]
        [Route("/employee/id/{eno}")]
        public IActionResult GetEmpById(int eno)
        {
            try
            {
                var emp = eObj.GetEmpById(eno);
                return Ok(emp);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        [HttpGet]
        [Route("/employee/designation/{designation}")]
        public IActionResult GetEmpByDesignation(string designation)
        {
            try
            {
                var emp = eObj.GetEmpByDesigantion(designation);
                return Ok(emp);
            }
            catch (Exception es)
            {
                return NotFound(es.Message);
            }
        }
        [HttpGet]
        [Route("/employee/total")]
        public IActionResult GetTotalEmployees()
        {
            var total = eObj.GetTotalEmployees();
            return Ok(total);
        }

        #endregion

        #region Post,Put and Delete
        [HttpPost]
        [Route("/employee/add")]
        public IActionResult AddNewEmployee([FromBody] Employee newEmp)
        {

            try
            {
                var addResult = eObj.AddNewEmployee(newEmp);
                return Created("", addResult);
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpDelete]
        [Route("/employee/delete/{empno}")]
        public IActionResult DeleteEmployee(int empno)
        {
            try
            {
                var deleteResult = eObj.DeleteEmployee(empno);
                return Accepted(deleteResult);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }


        [HttpPut]
        [Route("/employee/edit")]
        public IActionResult UpdateEmployee([FromBody] Employee changes)
        {
            try
            {
                var updateResult = eObj.UpdateEmployee(changes);
                return Accepted(updateResult);
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
        #endregion
    }
}
