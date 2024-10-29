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
    }
}
