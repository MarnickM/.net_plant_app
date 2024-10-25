using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantdrationAPI.DAL;

namespace PlantdrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        // use the Repositorie PLantRepository to inject it here and create all needed endpoints
        
        private readonly IR<Plant> _plantRepository;
    }
}
