using System.Collections.Generic;
using jwtnetcore31.Models;

namespace jwtnetcore31.Services {
    public interface IUserService {
        
        User Authenticate(string username, string password);
        
        IEnumerable<User> GetAll();
    }
}