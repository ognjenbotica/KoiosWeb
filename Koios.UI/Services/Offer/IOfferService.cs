using Koios.UI.Services.Base;

namespace Koios.UI.Services.Offer
{
    public interface IOfferService
    {
        Task<Response<OfferDto>> GetOfferById(int offerId);

        Task<Response<OfferDto>> CreateOffer(OfferDto offer);

        Task<Response<OfferDto>> UpdateOffer(OfferDto offer);

        Task<Response<OfferDto>> DeleteOffer(int offerId);

        Task<Response<List<OfferDto>>> GetOffers();
    }
}