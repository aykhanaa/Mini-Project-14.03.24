
using CourseApp.Controllers;
using Microsoft.VisualBasic;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

GroupContoller groupContoller = new GroupContoller();
StudentContoller studentContoller = new StudentContoller();


while (true)
{
    GetMenues();

Operation: string operationStr = Console.ReadLine();

    int opration;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out opration);

    if (isCorrectOperationFormat)
    {
        switch (opration)
        {
            case (int)OperationType.GroupCreate:
                groupContoller.Create();
                break;
            case (int)OperationType.GroupDelete:
                groupContoller.Delete();
                break;
            case (int)OperationType.GroupUpdate:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetGroupById:
                groupContoller.GetGroupById();
                break;
            case (int)OperationType.GetAllGroupByTeacher:
                groupContoller.GetAllByTeacher();
                break;
            case (int)OperationType.GetAllGroups:
                groupContoller.GetAll();
                break;
            case (int)OperationType.GetAllGroupByRoom:
                groupContoller.GetAllGroupByRoom();
                break;
            case (int)OperationType.SearchForGroupByName:
                groupContoller.SearchByName();
                break;
            case (int)OperationType.StudentCreate:
                studentContoller.Create();
                break;
            case (int)OperationType.StudentDelete:
                studentContoller.Delete();
                break;
            case (int)OperationType.StudentUpdate:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetStudentById:
                studentContoller.GetStudentById();
                break;
            case (int)OperationType.GetAllStudents:
                studentContoller.GetAll();
                break;
            case (int)OperationType.GetStudentByAge:
                studentContoller.GetStudentById();
                break;
            case (int)OperationType.GetStudentByGroup:
                studentContoller.GetStudentById();
                break;
            case (int)OperationType.SearchStudentByNameOrSurname:
                studentContoller.SearchByNameOrSurname();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;
        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }


}

static void  GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one opration: \n 1 - Group create\n 2 - Group delete\n 3 - Group update\n 4 - Get group by id\n 5 - Get all groups by teacher\n " +
                                                "6- Get all groups\n 7- Get all groups by room\n 8- Search method for groups by name\n 9- Student Create\n 10- Student Delete\n 11- Student Update\n 12- Get student by id\n" +
                                                " 13- Get all students\n 14- Get students by age\n 15- Get all students by group id\n 16- Search method for students by name or surname");
}