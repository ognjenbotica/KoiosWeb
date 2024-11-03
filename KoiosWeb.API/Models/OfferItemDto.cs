using KoiosWeb.API.Data;

namespace KoiosWeb.API.Models
{
    public class OfferItemDto : BaseDto
    {
        public int OfferId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int ComputerHardwareId { get; set; }

        public virtual ComputerHardwareDto? ComputerHardware { get; set; }
        public virtual OfferDto? Offer { get; set; }
    }
}
