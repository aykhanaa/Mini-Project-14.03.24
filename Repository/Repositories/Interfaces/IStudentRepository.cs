using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository:IBaseRepository<Student>
    {
      List<Student> GetByAge(int age);
        List<Student> GetByAge(int? age);
        List<Student> GetByGroup(int id);
        List<Student> GetByGroup(int? id);
        List<Student> GetByNameOrSurname(string text);
    

    }
}
