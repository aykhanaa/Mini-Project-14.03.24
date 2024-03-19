

using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Text.RegularExpressions;
using Group = Domain.Models.Group;


namespace CourseApp.Controllers
{
    internal class GroupContoller
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;


        public GroupContoller()
        {
            _groupService = new GroupService();
            _studentService = new StudentService();
        }

        public void Create()
        {
        Name: ConsoleColor.Cyan.WriteConsole("Add  group name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            var result = _groupService.SearchForByName(name);

            if (result!=null)
            {
                ConsoleColor.Red.WriteConsole("This group is exsist,please add  new name");
                goto Name;
            }
        Teacher: ConsoleColor.Cyan.WriteConsole("Add teacher name:");
            string teacherName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Teacher;
            }

            if (!Regex.IsMatch(teacherName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Teacher;
            }
            if (teacherName.Length < 3)
            {
                ConsoleColor.Red.WriteConsole("Teacher name is less 3 letter");
                goto Teacher;
            }

        RoomName: ConsoleColor.Cyan.WriteConsole("Add room name:");
            string roomName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto RoomName;
            }
            else
            {
                try
                {
                    _groupService.Create(new Domain.Models.Group { Name = name.Trim(), Teacher = teacherName.Trim(), Room = roomName.Trim() });
                    ConsoleColor.Green.WriteConsole("Data successfully added");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto RoomName;
                }
            }

        }

        public void GetAll()
        {
            var response = _groupService.GetAll();
            foreach (var item in response)
            {
                string data = $"Id:{item.Id},Group name:{item.Name},Group room: {item.Room},Group teacher:{item.Teacher}";
                Console.WriteLine(data);
            }
        }

        public void Delete()
        {
        Id: ConsoleColor.Cyan.WriteConsole("Add group id:");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _groupService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                  
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;

            }
        }

        public void GetGroupById()
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
                    _groupService.GetById(id);
                    var response = _groupService.GetById(id);
                    string data = $"Id:{response.Id},Group name:{response.Name},Group room: {response.Room},Group teacher:{response.Teacher}";
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

        public void GetAllGroupByRoom()
        {
        Room: ConsoleColor.Cyan.WriteConsole("Add room:");
            string room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
            var response = _groupService.GetAllWithExpression(m => m.Room.ToLower() == room.ToLower().Trim());
            if (response.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Room not found");
                return;
            }
            foreach (var item in response)
            {
                string data = $"Id:{item.Id},Group name:{item.Name},Group room: {item.Room},Group teacher:{item.Teacher}";
                Console.WriteLine(data);
            }

        }

        public void GetAllByTeacher()
        {
        Teacher: ConsoleColor.Cyan.WriteConsole("Add teacher:");
            string teacherName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Teacher;
            }
            var response = _groupService.GetAllWithExpression(m => m.Teacher.ToLower() == teacherName.ToLower().Trim());
            if (response.Count == 0)
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


        public void SearchByName()
        {
        Name: ConsoleColor.Cyan.WriteConsole("Add name:");
            string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            try
            {
                List<Group> responce = _groupService.GetAllByTeacher(searchText);
                if (responce.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Name not found");

                    foreach (var item in responce)
                    {
                        string data = $"Id:{item.Id},Group name:{item.Name},Group room: {item.Room},Group teacher:{item.Teacher}";
                        Console.WriteLine(data);
                    }
                }
            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole("Name not found");
                goto Name;

            }

        }
    }
}
 