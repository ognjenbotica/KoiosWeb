using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiosWeb.API.Repositories
{
    public class OfferRepository : RepositoryBase<KoiosDBContext, Offer>, IOfferRepository
    {
        private readonly KoiosDBContext context;
        public OfferRepository(KoiosDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Offer>> GetOffersAsync()
        {
            return await context.Offers
                .Include(q => q.OfferItems)
                .ThenInclude(q => q.ComputerHardware)
                .ThenInclude(q => q.Type)
                .ToListAsync();
        }

        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await context.Offers.Include(q => q.OfferItems).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Offer?> CreateOfferAsync(Offer offer)
        {
            return await CreateAsync(offer);
        }

        public async Task UpdateOfferAsync(Offer offer)
        {
            await UpdateAsync(offer);
        }

        public async Task DeleteOfferAsync(Offer offer)
        {
            await DeleteAsync(offer);
        }
    }
}
