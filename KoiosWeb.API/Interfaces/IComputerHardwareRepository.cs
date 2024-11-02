using KoiosWeb.API.Data;

namespace KoiosWeb.API.Interfaces
{
    public interface IComputerHardwareRepository
    {
        Task<List<ComputerHardware>> GetComputerHardwareAsync();
    }
}