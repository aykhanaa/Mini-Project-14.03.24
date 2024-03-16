using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    internal interface IStudentService
    {
        void Create(Student data);
        void Update(Student data);
        void Delete(Student data);
        Student GetById(int? id);
        List<Student> GetAll();
        List<Student> GetByAge(int age);
        List<Student> GetByGroup(int id);
        List<Student> GetByNameOrSurname(string text);

    }
}
