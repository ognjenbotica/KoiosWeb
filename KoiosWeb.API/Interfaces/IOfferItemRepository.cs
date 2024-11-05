using KoiosWeb.API.Data;

namespace KoiosWeb.API.Interfaces
{
    public interface IOfferItemRepository
    {
        Task<OfferItem?> GetOfferItemAsync(int id);
        Task<OfferItem?> CreateOfferItemAsync(OfferItem offerItem);
        Task UpdateOfferItemAsync(OfferItem offerItem);
        Task DeleteOfferItemAsync(OfferItem offerItem);
    }
}