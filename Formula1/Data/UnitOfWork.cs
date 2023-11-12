using Formula1.Core;
using Formula1.Core.Repositories;
using Formula1.Models;

namespace Formula1.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDB _context;
        public IDriverRepository Drivers { get; private set; }
        public UnitOfWork(ApplicationDB context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");
            Drivers = new DriverRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
