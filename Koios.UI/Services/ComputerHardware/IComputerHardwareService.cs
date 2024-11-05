using Koios.UI.Services.Base;

namespace Koios.UI.Services.ComputerHardware
{
    public interface IComputerHardwareService
    {
        Task<Response<List<ComputerHardwareDto>>> GetComputerHardware();
    }
}