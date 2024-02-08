using Microsoft.EntityFrameworkCore;
using PaltinumTask.Data;
using PaltinumTask.IRepository;
using PaltinumTask.Model;

namespace PaltinumTask.Repository
{
    public class PlatinumRepository : IPlatinumRepository
    {
        private readonly DbContextRepo dbContextRepo;

        public PlatinumRepository(DbContextRepo dbContextRepo)
        {
            this.dbContextRepo = dbContextRepo;
        }
        // Create New User
        public async Task<Platinum> CreateAsync(Platinum platinum)
        {
            await dbContextRepo.platinums.AddAsync(platinum);
            await dbContextRepo.SaveChangesAsync();
            return platinum;
        }
        // Delete User By Id
        public async Task<Platinum?> DeleteAsync(Guid id)
        {
            var result = await dbContextRepo.platinums.FirstOrDefaultAsync(x => x.Id == id);
           
            if (result == null)
            {
                return null;
            }

            dbContextRepo.platinums.Remove(result);
            dbContextRepo.SaveChangesAsync();
            return result;
        }

        // Get Id For User
        public async Task<Platinum?> GetById(Guid id)
        {
            return await dbContextRepo.platinums.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Get ALl User Data
        public async Task<List<Platinum>> GetAll()
        {
            return await dbContextRepo.platinums.ToListAsync();
        }
        
        // Update Form
        public async Task<Platinum> UpdateAsync(Guid id, Platinum platinum)
        {
            var result = await dbContextRepo.platinums.FirstOrDefaultAsync(x => x.Id == id);

            if(result == null)
            {
                return null;
            }

            result.FirstName = platinum.FirstName;
            result.LastName = platinum.LastName;
            result.DateOfBirth = platinum.DateOfBirth;
            result.DepartmentName = platinum.DepartmentName;
            result.Status = platinum.Status;
            await dbContextRepo.SaveChangesAsync();
            return result;
        }
    }
}
