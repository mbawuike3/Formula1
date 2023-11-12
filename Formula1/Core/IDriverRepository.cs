using Formula1.Models;

namespace Formula1.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetByDriverNb (int  driverNb);
    }
}
