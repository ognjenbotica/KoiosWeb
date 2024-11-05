using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;

namespace KoiosWeb.API.Repositories
{
    public class OfferItemRepository : RepositoryBase<KoiosDBContext, OfferItem>, IOfferItemRepository
    {
        private readonly KoiosDBContext context;
        public OfferItemRepository(KoiosDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<OfferItem?> GetOfferItemAsync(int id)
        {
            return await context.OfferItems.FindAsync(id);
        }

        public async Task<OfferItem?> CreateOfferItemAsync(OfferItem offerItem)
        {
            var tempOfferItem = new OfferItem
            {
                OfferId = offerItem.OfferId,
                ComputerHardwareId = offerItem.ComputerHardwareId,
                Amount = offerItem.Amount,
            };

            context.OfferItems.Add(tempOfferItem);
            await context.SaveChangesAsync();

            return offerItem;
        }

        public async Task UpdateOfferItemAsync(OfferItem offerItem)
        {
            await UpdateAsync(offerItem);
        }

        public async Task DeleteOfferItemAsync(OfferItem offerItem)
        {
            await DeleteAsync(offerItem);
        }
    }
}
