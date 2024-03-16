using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group data);
        void Delete(int? id);
        void Update (Group data);
        Group GetById(int? id);
        List<Group> GetAllByTeacher(string roomName);
        List<Group> GetAll();
        List<Group> GetAllByRoom(string roomName);
        Group SearchForByName(string str);

    }
}
