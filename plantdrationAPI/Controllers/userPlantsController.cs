using Microsoft.AspNetCore.Mvc;
using PlantdrationAPI.DAL;
using plantdrationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantdrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlantsController : ControllerBase
    {
        private readonly UserPlantRepository _userPlantRepository; 

        public UserPlantsController(UserPlantRepository userPlantRepository)
        {
            _userPlantRepository = userPlantRepository;
        }

        // GET: api/userPlants/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserPlant>>> GetByUserId(int id)
        {
            var userPlants = await _userPlantRepository.GetByID(id);

            if (userPlants == null)
            {
                return NotFound();
            }

            return Ok(userPlants);
        }

        // POST: api/userPlants
        [HttpPost]
        public async Task<ActionResult<UserPlant>> CreateUserPlant(UserPlant userPlant)
        {
            if (userPlant == null)
            {
                return BadRequest();
            }

            await _userPlantRepository.Insert(userPlant);
            await _userPlantRepository.Save();
            return CreatedAtAction("CreateUserPlant", new { id = userPlant.UserId }, userPlant);
        }

        // PUT: api/userPlants/{userid}/{plantid}
        [HttpPut("{userid}/{plantid}")]
        public async Task<ActionResult<UserPlant>> UpdateUserPlant(int userid, int plantid, UserPlant userPlant)
        {
            if (userid != userPlant.UserId || plantid != userPlant.PlantId)
            {
                return BadRequest("User ID or Plant ID mismatch.");
            }

            // Fetch the existing UserPlant
            var existingUserPlant = await _userPlantRepository.GetByUserIdAndPlantId(userid, plantid);
            if (existingUserPlant == null)
            {
                return NotFound("UserPlant not found.");
            }

            existingUserPlant.LastWatered = userPlant.LastWatered;

            await _userPlantRepository.Save();
            return Ok(existingUserPlant);
        }

    }
}
