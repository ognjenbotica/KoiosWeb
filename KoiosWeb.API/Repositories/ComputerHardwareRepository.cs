using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiosWeb.API.Repositories
{
    public class ComputerHardwareRepository : RepositoryBase<KoiosDBContext, ComputerHardware>, IComputerHardwareRepository
    {
        private readonly KoiosDBContext context;
        public ComputerHardwareRepository(KoiosDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ComputerHardware>> GetComputerHardwareAsync()
        {
            return await context.ComputerHardwares.Include(q => q.HardwareSpecs).ToListAsync();
        }
    }
}
