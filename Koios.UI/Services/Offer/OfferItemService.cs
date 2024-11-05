using Koios.UI.Services.Base;

namespace Koios.UI.Services.Offer
{
    public class OfferItemService : BaseHttpService, IOfferItemService
    {
        private readonly IClient httpClient;
        public OfferItemService(IClient httpClient) : base()
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<OfferItemDto>> GetOfferItemById(int offerItemId)
        {
            Response<OfferItemDto> response;

            try
            {
                var data = await httpClient.OfferItemGETAsync(offerItemId);
                response = new Response<OfferItemDto>
                {
                    Data = data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferItemDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferItemDto>> DeleteOfferItem(int offerItemId)
        {
            Response<OfferItemDto> response;

            try
            {
                await httpClient.OfferItemDELETEAsync(offerItemId);
                response = new Response<OfferItemDto>
                {
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferItemDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferItemDto>> CreateOfferItem(OfferItemDto offerItem)
        {
            Response<OfferItemDto> response;

            try
            {
                var data = await httpClient.OfferItemPOSTAsync(offerItem);
                response = new Response<OfferItemDto>
                {
                    Data = data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferItemDto>(exception);
            }

            return response;
        }

        public async Task<Response<OfferItemDto>> UpdateOfferItem(OfferItemDto offerItem)
        {
            Response<OfferItemDto> response;

            try
            {
                var data = await httpClient.OfferItemPUTAsync(offerItem);
                response = new Response<OfferItemDto>
                {
                    Data = data,
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<OfferItemDto>(exception);
            }

            return response;
        }
    }
}
