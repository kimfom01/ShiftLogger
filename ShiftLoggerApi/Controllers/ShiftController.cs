using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApi.Data;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public ShiftController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        // GET: api/Shift
        [HttpGet]
        public IEnumerable<Shift> GetShifts()
        {
            return _dataAccess.GetShifts();
        }

        // GET: api/Shift/5
        [HttpGet("{id}", Name = "Get")]
        public Shift GetShift(int id)
        {
            return _dataAccess.GetShiftById(id);
        }

        // POST: api/Shift
        [HttpPost]
        public void Post([FromBody] Shift shift)
        {
            _dataAccess.AddShift(shift);
        }

        // PUT: api/Shift/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shift shift)
        {
            _dataAccess.UpdateShift(id, shift);
        }

        // DELETE: api/Shift/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataAccess.DeleteShift(id);
        }
    }
}
