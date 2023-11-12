using Formula1.Core;
using Formula1.Data;
using Formula1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Drivers.All());
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }
        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null) return NotFound();
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
        [HttpPatch]
        [Route("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existingDriver = await _unitOfWork.Drivers.GetById(driver.Id);
            if (existingDriver == null) return NotFound();
            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
