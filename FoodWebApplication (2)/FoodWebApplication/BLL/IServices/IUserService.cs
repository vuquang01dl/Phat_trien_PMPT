using DTO;
using DTO.User;
using Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IUserService
    {
        void Create(UserDTO input);
        void Update(UserDTO input, long id);
        void Delete(long id);
        UserDTO GetById(long id);
        PaginationModels<List<UserDTO>> Get(string search);
        List<UserDTO> GetAllUser();
        UserDTO Login(string username, string pass);
    }
}
