using Koios.UI.Services.Base;

namespace Koios.UI.Services.Offer
{
    public interface IOfferItemService
    {
        Task<Response<OfferItemDto>> GetOfferItemById(int offerItemId);

        Task<Response<OfferItemDto>> DeleteOfferItem(int offerItemId);

        Task<Response<OfferItemDto>> CreateOfferItem(OfferItemDto offerItem);

        Task<Response<OfferItemDto>> UpdateOfferItem(OfferItemDto offerItem);
    }
}