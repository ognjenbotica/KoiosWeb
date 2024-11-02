using KoiosWeb.API.Data;

namespace KoiosWeb.API.Interfaces
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetOffersAsync();

        Task<Offer?> GetOfferByIdAsync(int id);

        Task<Offer?> CreateOfferAsync(Offer offer);

        Task UpdateOfferAsync(Offer offer);

        Task DeleteOfferAsync(Offer offer);
    }
}