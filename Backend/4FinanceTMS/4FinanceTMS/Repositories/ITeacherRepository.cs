using _4FinanceTMS.Models;

namespace _4FinanceTMS.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();

        Task<Teacher> GetAsync(Guid id);

        Task <Teacher> CreateTeacherAsync(Teacher teacher);

        Task<Teacher> DeleteTeacherAsync(Guid id);

        Task<Teacher> UpdateTeacherAsync(Guid id, Teacher teacher);
    }
}
