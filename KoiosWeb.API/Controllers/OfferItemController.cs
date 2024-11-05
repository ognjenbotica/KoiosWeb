using AutoMapper;
using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;
using KoiosWeb.API.Models;
using KoiosWeb.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KoiosWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferItemController : ControllerBase
    {
        private readonly IOfferItemRepository offerItemRepository;
        private readonly IMapper mapper;
        private readonly ILogger<OfferController> logger;

        public OfferItemController(IOfferItemRepository offerItemRepository, IMapper mapper, ILogger<OfferController> logger)
        {
            this.offerItemRepository = offerItemRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferItemDto>> GetOfferItem(int id)
        {
            try
            {
                var offerItem = await offerItemRepository.GetOfferItemAsync(id);
                if (offerItem == null)
                {
                    return NotFound();
                }
                var offerItemDto = mapper.Map<OfferItemDto>(offerItem);
                return Ok(offerItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetOfferItem)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OfferItemDto>> CreateOfferItem(OfferItemDto offerItemDto)
        {
            try
            {
                var offerItem = mapper.Map<OfferItem>(offerItemDto);
                var createdOfferItem = await offerItemRepository.CreateOfferItemAsync(offerItem);
                var createdOfferItemDto = mapper.Map<OfferItemDto>(createdOfferItem);
                return Ok(createdOfferItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(CreateOfferItem)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<OfferItemDto>> UpdateOfferItem(OfferItemDto offerItemDto)
        {
            try
            {
                var offerItem = mapper.Map<OfferItem>(offerItemDto);
                await offerItemRepository.UpdateOfferItemAsync(offerItem);
                return Ok(offerItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(UpdateOfferItem)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOfferItem(int id)
        {
            try
            {
                var offer = await offerItemRepository.GetOfferItemAsync(id);
                if (offer == null)
                {
                    return NotFound();
                }
                await offerItemRepository.DeleteOfferItemAsync(offer);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(DeleteOfferItem)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
