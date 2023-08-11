using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using employeeAPI_EF.Models.EF;

namespace employeeAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentController : ControllerBase
    {
        private readonly EmployeeManagementDbContext _context = new EmployeeManagementDbContext();

        //public departmentController(EmployeeManagementDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptDetail>>> GetDeptDetails()
        {
          if (_context.DeptDetails == null)
          {
              return NotFound();
          }
            return await _context.DeptDetails.ToListAsync();
        }

        // GET: api/department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeptDetail>> GetDeptDetail(int id)
        {
          if (_context.DeptDetails == null)
          {
              return NotFound();
          }
            var deptDetail = await _context.DeptDetails.FindAsync(id);

            if (deptDetail == null)
            {
                return NotFound();
            }

            return deptDetail;
        }

        // PUT: api/department/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeptDetail(int id, DeptDetail deptDetail)
        {
            if (id != deptDetail.DeptNo)
            {
                return BadRequest();
            }

            _context.Entry(deptDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/department
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeptDetail>> PostDeptDetail(DeptDetail deptDetail)
        {
          if (_context.DeptDetails == null)
          {
              return Problem("Entity set 'EmployeeManagementDbContext.DeptDetails'  is null.");
          }
            _context.DeptDetails.Add(deptDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeptDetailExists(deptDetail.DeptNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeptDetail", new { id = deptDetail.DeptNo }, deptDetail);
        }

        // DELETE: api/department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeptDetail(int id)
        {
            if (_context.DeptDetails == null)
            {
                return NotFound();
            }
            var deptDetail = await _context.DeptDetails.FindAsync(id);
            if (deptDetail == null)
            {
                return NotFound();
            }

            _context.DeptDetails.Remove(deptDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptDetailExists(int id)
        {
            return (_context.DeptDetails?.Any(e => e.DeptNo == id)).GetValueOrDefault();
        }
    }
}
