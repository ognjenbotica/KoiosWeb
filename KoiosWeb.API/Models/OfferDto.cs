using KoiosWeb.API.Data;

namespace KoiosWeb.API.Models
{
    public class OfferDto : BaseDto
    {
        public int ComputerHardwareId { get; set; }

        public int Amount { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ComputerHardwareDto? ComputerHardware { get; set; }
    }
}
