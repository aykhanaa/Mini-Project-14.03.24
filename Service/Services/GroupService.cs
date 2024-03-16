using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private int count = 1;
        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        public void Create(Group data)
        {
            if (data is null) throw new ArgumentNullException();
            data.Id = count;
            _groupRepo.Create(data);
            count++;
        }
       
        public void Delete(int? id)
        {
           if (id is null) throw new ArgumentNullException();

            Group group = _groupRepo.GetById((int)id);

            if(group is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _groupRepo.Delete(group);   
        }


        public List<Group> GetAll()
        {
            return _groupRepo.GetAll();
        }

        public List<Group> GetAllByRoom(string roomName)
        {
           var response = _groupRepo.GetAllByRoom(roomName);
            return response;
        }

        public List<Group> GetAllByTeacher(string roomName)
        {
            var response = _groupRepo.GetAllByRoom(roomName);
            return response;
        }

        public Group GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Group group = _groupRepo.GetById((int)id);

            if (group is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            return group;
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchForByName(string str)
        {
            throw new NotImplementedException();
        }
    }
}
