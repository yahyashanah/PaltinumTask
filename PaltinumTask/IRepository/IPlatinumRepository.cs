using PaltinumTask.Model;

namespace PaltinumTask.IRepository
{
    public interface IPlatinumRepository
    {
        Task<List<Platinum>> GetAll();
        Task<Platinum?> GetById(Guid id);
        Task<Platinum> CreateAsync(Platinum platinum);
        Task<Platinum?> UpdateAsync(Guid id,Platinum platinum);
        Task<Platinum?> DeleteAsync(Guid id);
    }
}
