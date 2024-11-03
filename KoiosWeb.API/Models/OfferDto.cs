using KoiosWeb.API.Data;

namespace KoiosWeb.API.Models
{
    public class OfferDto : BaseDto
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateChanged { get; set; }

        public virtual ICollection<OfferItemDto> OfferItems { get; set; } = new List<OfferItemDto>();
    }
}
