using Koios.UI.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace Koios.UI.Model
{
    public class AddOfferItemModel
    {
        public int Id { get; set; }

        public int OfferId { get; set; }

        [Required(ErrorMessage = "Količina mora biti unesena!")]
        [Range(1, int.MaxValue, ErrorMessage = "Količina mora biti veća od 0!")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Cijena mora biti veća od 0!")]
        public decimal Price { get; set; }

        public int? ComputerHardwareId { get; set; }

        [Required(ErrorMessage = "Morate odabrati komponentu!")]
        public string? Model { get; set; }

        public ComputerHardwareDto? ComputerHardware { get; set; }
    }
}
