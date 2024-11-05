using System.ComponentModel.DataAnnotations;

namespace Koios.UI.Model
{
    public class EditOfferModel
    {
        public int Id { get; set; }
        public DateTime DateChanged { get; set; }

        public DateTime DateCreated { get; set; }

        [Required, MinLength(1, ErrorMessage = "Mora biti barem jedna stavka u ponudi.")]
        public List<AddOfferItemModel> OfferItems { get; set; } = new List<AddOfferItemModel>();
    }
}
