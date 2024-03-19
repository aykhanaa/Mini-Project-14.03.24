using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student data);
        void Update(Student data);
        void Delete(int? id);
        Student GetById(int? id);
        List<Student> GetAll();
        List<Student> GetAllByAge(int? age);
        List<Student> GetAllByGroup(int? id);
        List<Student> SearchByNameOrSurname(string text);

    }
}
