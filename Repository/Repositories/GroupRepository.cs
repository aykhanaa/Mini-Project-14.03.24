using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> GetAllByRoom(string roomName)
        {
            return AppDbContext<Group>.datas.Where(m=>m.Room == roomName).ToList();
        }

        public List<Group> GetAllByTeacher(string teacherName)
        {
            return AppDbContext<Group>.datas.Where(m=>m.Teacher == teacherName).ToList();
        }
    }
}
 