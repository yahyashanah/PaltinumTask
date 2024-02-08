using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaltinumTask.Data;
using PaltinumTask.IRepository;
using PaltinumTask.Model;
using PaltinumTask.Repository;

namespace PaltinumTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PlatinumController : ControllerBase
    {
        private readonly IPlatinumRepository platinumRepository;

        public PlatinumController(IPlatinumRepository platinumRepository)
        {
            this.platinumRepository = platinumRepository;
        }

        // Create New User
        [HttpPost]
        public async Task<IActionResult> CreatePost(Platinum platinum)
        {
            var result = await platinumRepository.CreateAsync(platinum);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Get All Users
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await platinumRepository.GetAll();

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Get User By Id
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var result = await platinumRepository.GetById(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Update User Information
        [HttpPut]
        public async Task<IActionResult> Update(Guid id,Platinum platinum)
        {
            var result = await platinumRepository.UpdateAsync(id,platinum);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Delete User By Id
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await platinumRepository.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
