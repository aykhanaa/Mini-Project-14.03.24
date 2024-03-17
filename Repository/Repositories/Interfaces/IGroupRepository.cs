using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository:IBaseRepository<Group>
    {
        List<Group> GetAllByTeacher(string teacherName);
        List<Group> GetAllByRoom(string roomName);
        
    }
}
