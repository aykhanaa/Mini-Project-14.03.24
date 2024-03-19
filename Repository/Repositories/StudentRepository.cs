using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> GetByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(m=>m.Age==age).ToList();
        }

        public List<Student> GetByAge(int? age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByGroup(int id)
        {
            return AppDbContext<Student>.datas.Where(m => m.Group.Id == id).ToList();
        }

        public List<Student> GetByGroup(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByNameOrSurname(string text)
        {
            return AppDbContext<Student>.datas.Where(m => m.Name==text||m.Surname==text).ToList();
        }
    }
}
