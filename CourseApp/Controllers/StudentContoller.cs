using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Helpers.Extensions;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Domain.Models;
using Service.Services.Interfaces;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    public class StudentContoller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;


        public StudentContoller()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }

        public void Create()
        {
            if (_groupService.GetAll().Count == 0)
            {
                ConsoleColor.Red.WriteConsole("First create group");
                return;
            }

        Name: ConsoleColor.Yellow.WriteConsole("Add name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Name; ;
            }
            if (name.Length < 3)
            {
                ConsoleColor.Red.WriteConsole("Name is less 3 letter");
                goto Name;
            }


        Surname: ConsoleColor.Yellow.WriteConsole("Add surname:");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Surname;
            }
            if (!Regex.IsMatch(surname, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Surname; ;
            }
            if (name.Length < 3)
            {
                ConsoleColor.Red.WriteConsole("Surname is less 3 letter");
                goto Surname;
            }


        Age: ConsoleColor.Yellow.WriteConsole("Add age:");
            string ageStr = Console.ReadLine();

            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);
            if (age < 14||age>50)
            {
                ConsoleColor.Red.WriteConsole("Age is under limit");
                goto Age;
            }
            if (isCorrectAgeFormat)
            {
                Idstr: ConsoleColor.Yellow.WriteConsole("Add group name");
                string groupname = Console.ReadLine();
               
              
                if (!string.IsNullOrWhiteSpace(groupname))
                {
                    try
                    {
                        var response = _groupService.SearchForByName(groupname);
                        //var response = _groupService.GetAllByTeacher(teachername);

                        if (response ==null)
                        {
                            ConsoleColor.Red.WriteConsole("Data not found");
                        }
                        else
                        {
                            _studentService.Create(new Student { Name = name, Surname = surname, Age = age, Group = response });

                            ConsoleColor.Green.WriteConsole("Data successfully added");
                        }


                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto Idstr;
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Group Name   Wrong format");
                    goto Idstr;
                }


            }
            else
            {
                ConsoleColor.Red.WriteConsole("Wrong age format");
                goto Age;
            }
            

        }
        public void GetAll()
        {
            var response = _studentService.GetAll();

            foreach (var item in response)
            {
                string data = $"Id:{item.Id},Student name:{item.Surname},Student age: {item.Age},Student group:{item.Group}";
                Console.WriteLine(data);

            }
        }
       public void GetStudentById()
        {
        Id: ConsoleColor.Cyan.WriteConsole("Add id:");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole("Input can't be empty");
                    goto Id;
                }
                try
                {
                    _studentService.GetById(id);
                    var response = _studentService.GetById(id);
                    string data = $"Id:{response.Id},Student name:{response.Surname},Student age: {response.Age},Student group:{response.Group}";
                    Console.WriteLine(data);

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong");
                goto Id;
            }
        }

        public void SearchByNameOrSurname()
        {
        SearchByName: ConsoleColor.Cyan.WriteConsole("Add search text");
            string str = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(str))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto SearchByName;
            }
            try
            {
                var response = _groupService.GetAllWithExpression(m => m.Name.ToLower().Trim().Contains(str.ToLower().Trim()));
                if (response is null)
                {
                    ConsoleColor.Red.WriteConsole("Group not found");
                    return;
                }
                foreach (var item in response)
                {
                    string data = $"Id:{item.Id},Group name:{item.Name},Group room: {item.Room},Group teacher:{item.Teacher}";
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchByName;
            }
        }
        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Add student id:");
        Idstr: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _studentService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Idstr;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Idstr;
            }
        }
        

    }
}
