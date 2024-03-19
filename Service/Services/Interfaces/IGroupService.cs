using Domain.Models;


namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group data);
        void Delete(int? id);
        void Update (Group data);
        Group GetById(int? id);
        List<Group> GetAllByTeacher(string teacherName);
        List<Group> GetAll();
        List<Group> GetAllByRoom(string roomName);
        Group SearchForByName (string str);

        List<Group> GetAllWithExpression(Func<Group, bool> predicate);

    }
}
