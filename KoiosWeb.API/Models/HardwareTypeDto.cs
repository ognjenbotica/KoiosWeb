
namespace KoiosWeb.API.Models
{
    public class HardwareTypeDto : BaseDto
    {
        public string? TypeName { get; set; }

        public virtual ICollection<ComputerHardwareDto> ComputerHardwares { get; set; } = new List<ComputerHardwareDto>();
    }
}
