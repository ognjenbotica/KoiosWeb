using Koios.UI.Services.Base;
using Koios.UI.Services.Offer;

namespace Koios.UI.Services.ComputerHardware
{
    public class ComputerHardwareService : BaseHttpService, IComputerHardwareService
    {
        private readonly IClient httpClient;
        public ComputerHardwareService(IClient httpClient) : base()
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<List<ComputerHardwareDto>>> GetComputerHardware()
        {
            Response<List<ComputerHardwareDto>> response;

            try
            {
                var data = await httpClient.ComputerHardwareAsync();
                response = new Response<List<ComputerHardwareDto>>
                {
                    Data = (List<ComputerHardwareDto>)data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<ComputerHardwareDto>>(exception);
            }

            return response;
        }
    }
}
