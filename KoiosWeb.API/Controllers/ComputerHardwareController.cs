using AutoMapper;
using KoiosWeb.API.Interfaces;
using KoiosWeb.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoiosWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerHardwareController : ControllerBase
    {
        private readonly IComputerHardwareRepository computerHardwareRepository;
        private readonly IMapper mapper;
        private readonly ILogger<ComputerHardwareController> logger;

        public ComputerHardwareController(IComputerHardwareRepository computerHardwareRepository, IMapper mapper, ILogger<ComputerHardwareController> logger)
        {
            this.computerHardwareRepository = computerHardwareRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerHardwareDto>>> GetComputerHardware()
        {
            try
            {
                var computerHardware = await computerHardwareRepository.GetComputerHardwareAsync();
                var computerHardwareDto = mapper.Map<IEnumerable<ComputerHardwareDto>>(computerHardware);
                return Ok(computerHardwareDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetComputerHardware)} action: {ex}");
                return StatusCode(500, "Internal server error");

            }
        }
    }  
}
