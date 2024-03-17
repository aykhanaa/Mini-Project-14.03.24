using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private int count = 1;
      
        public void Create(Student data)
        {
            if (data == null) throw new ArgumentNullException();
            data.Id = count;
            _studentRepo.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
          if (id is null) throw new ArgumentNullException();
          Student student = _studentRepo.GetById((int)id);
            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);
            _studentRepo.Delete(student);
        }

        public List<Student> GetAll()
        {
           return _studentRepo.GetAll();
        }

        public List<Student> GetByAge(int age)
        {
            return _studentRepo.GetByAge(age);
        }

        public List<Student> GetByGroup(int id)
        {
           return _studentRepo.GetByGroup(id);
        }

        public Student GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            Student student = _studentRepo.GetById((int)id);
            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);
            return student;
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
         return _studentRepo.GetByNameOrSurname(text);
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
