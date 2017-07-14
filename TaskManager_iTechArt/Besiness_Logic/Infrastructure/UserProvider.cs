using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager_iTechArt.Besiness_Logic.DTO;
using TaskManager_iTechArt.Besiness_Logic.Interface;

namespace TaskManager_iTechArt.Besiness_Logic.Infrastructure
{
    public class UserProvider : IProvider<UserDTO>
    {
        public void Delete(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Make(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO item)
        {
            throw new NotImplementedException();
        }
    }
}