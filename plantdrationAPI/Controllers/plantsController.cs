using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantdrationAPI.DAL;
using plantdrationAPI.Models;

namespace PlantdrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class plantsController : ControllerBase
    {
        private readonly IRepository<Plant> _plantRepository;

        public plantsController(IRepository<Plant> plantRepository)
        {
            _plantRepository = plantRepository;
        }

        // GET: api/plants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetAllPlants()
        {
            var plants = await _plantRepository.GetAll();
            return Ok(plants);
        }

        // GET: api/plants/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlantById(int id)
        {
            var plant = await _plantRepository.GetByID(id);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        // GET: api/plants/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Plant>> GetPlantByName(string name)
        {
            var plant = await _plantRepository.GetByName(name);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }


        // POST: api/plants
        [HttpPost]
        public async Task<ActionResult<Plant>> CreatePlant(Plant plant)
        {
            if (plant == null)
            {
                return BadRequest();
            }

            await _plantRepository.Insert(plant);
            await _plantRepository.Save();
            return CreatedAtAction(nameof(GetPlantById), new { id = plant.Id }, plant);
        }

        // PUT: api/plants/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlant(int id,Plant plant)
        {
            if (plant == null || plant.Id != id)
            {
                return BadRequest();
            }

            var existingPlant = await _plantRepository.GetByID(id);
            if (existingPlant == null)
            {
                return NotFound();
            }

            _plantRepository.Update(plant);
            await _plantRepository.Save();
            return NoContent();
        }

        // DELETE: api/plants/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlant(int id)
        {
            var plant = await _plantRepository.GetByID(id);
            if (plant == null)
            {
                return NotFound();
            }

            _plantRepository.Delete(id);
            await _plantRepository.Save();
            return NoContent();
        }
    }
}
