using KoiosWeb.API.Data;

namespace KoiosWeb.API.Models
{
    public class ComputerHardwareDto : BaseDto
    {
        public int? TypeId { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<HardwareSpecDto> HardwareSpecs { get; set; } = new List<HardwareSpecDto>();

        public virtual HardwareTypeDto? Type { get; set; }
    }
}