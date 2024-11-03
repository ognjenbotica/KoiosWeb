using Koios.UI.Services.Base;

namespace Koios.UI.Services.Offer
{
    public class OfferService : BaseHttpService, IOfferService
    {
        private readonly IClient httpClient;
        public OfferService(IClient httpClient) : base()
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<OfferDto>> GetOfferById(int offerId)
        {
            Response<OfferDto> response;

            try
            {
                var data = await httpClient.OfferGETAsync(offerId);
                response = new Response<OfferDto>
                {
                    Data = data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferDto>> CreateOffer(OfferDto offer)
        {
            Response<OfferDto> response;

            try
            {
                var data = await httpClient.OfferPOSTAsync(offer);
                response = new Response<OfferDto>
                {
                    Data = data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferDto>> UpdateOffer(OfferDto offer)
        {
            Response<OfferDto> response;

            try
            {
                await httpClient.OfferPUTAsync(offer);
                response = new Response<OfferDto>
                {
                    Data = offer,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferDto>> DeleteOffer(int offerId)
        {
            Response<OfferDto> response;

            try
            {
                await httpClient.OfferDELETEAsync(offerId);
                response = new Response<OfferDto>
                {
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferDto>(exception);
            }

            return response;
        }

        public async Task<Response<List<OfferDto>>> GetOffers()
        {
            Response<List<OfferDto>> response;

            try
            {
                var data = await httpClient.OfferAllAsync();
                response = new Response<List<OfferDto>>
                {
                    Data = (List<OfferDto>)data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<OfferDto>>(exception);
            }

            return response;
        }
    }
}

