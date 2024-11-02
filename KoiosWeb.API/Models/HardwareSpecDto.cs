namespace KoiosWeb.API.Models
{
    public class HardwareSpecDto : BaseDto
    {
        public int? HardwareId { get; set; }

        public string? SpecKey { get; set; }

        public string? SpecValue { get; set; }

        public virtual ComputerHardwareDto? Hardware { get; set; }
    }
}
