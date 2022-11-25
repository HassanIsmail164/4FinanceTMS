using _4FinanceTMS.Data;
using _4FinanceTMS.Models;
using Microsoft.EntityFrameworkCore;

namespace _4FinanceTMS.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        // instance form the TMSDbContext
        private readonly TMSDbContext _TMSDbContext;
        
        // constructor that inject the _TMSDbContext in the class
        public TeacherRepository(TMSDbContext tmsDbContext)
        {
            this._TMSDbContext = tmsDbContext;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _TMSDbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetAsync(Guid id)
        {
            return await _TMSDbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            teacher.Id = new Guid();
            await _TMSDbContext.Teachers.AddAsync(teacher);
            await _TMSDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeacherAsync(Guid id)
        {
            var teacher = await _TMSDbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
            {
                return null;
            }

            _TMSDbContext.Teachers.Remove(teacher);
            await _TMSDbContext.SaveChangesAsync();
            return teacher; 
        }

        public async Task<Teacher> UpdateTeacherAsync(Guid id, Teacher teacher)
        {
            var existingTeacher = await _TMSDbContext.Teachers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingTeacher == null) { return null; }

            existingTeacher.Name = teacher.Name;
            existingTeacher.Email = existingTeacher.Email;   
            existingTeacher.Specality = teacher.Specality;

            await _TMSDbContext.SaveChangesAsync();
            return existingTeacher;
        }
    }
}
