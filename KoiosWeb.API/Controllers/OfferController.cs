using AutoMapper;
using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;
using KoiosWeb.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoiosWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<OfferController> logger;

        public OfferController(IOfferRepository offerRepository, IMapper mapper, ILogger<OfferController> logger)
        {
            this.offerRepository = offerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetOffers()
        {
            try
            {
                var offers = await offerRepository.GetOffersAsync();
                var offersDto = mapper.Map<IEnumerable<OfferDto>>(offers);
                return Ok(offersDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetOffers)} action: {ex}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> GetOffer(int id)
        {
            try
            {
                var offer = await offerRepository.GetOfferByIdAsync(id);
                if (offer == null)
                {
                    return NotFound();
                }
                var offerDto = mapper.Map<OfferDto>(offer);
                return Ok(offerDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(GetOffer)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OfferDto>> CreateOffer(OfferDto offerDto)
        {
            try
            {
                var offer = mapper.Map<Offer>(offerDto);
                var newOffer = await offerRepository.CreateOfferAsync(offer);
                var newOfferDto = mapper.Map<OfferDto>(newOffer);
                return CreatedAtAction(nameof(GetOffer), new { id = newOfferDto.Id }, newOfferDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(CreateOffer)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOffer(OfferDto offerDto)
        {
            try
            {
                var offer = mapper.Map<Offer>(offerDto);
                await offerRepository.UpdateOfferAsync(offer);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(UpdateOffer)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOffer(int id)
        {
            try
            {
                var offer = await offerRepository.GetOfferByIdAsync(id);
                if (offer == null)
                {
                    return NotFound();
                }
                await offerRepository.DeleteOfferAsync(offer);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in the {nameof(DeleteOffer)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }  
}
