using System.Collections.Generic;
using System.Linq;
using jwtnetcore31.Models;

namespace jwtnetcore31.Helpers {
    public static class ExtensionMethods {

        public static IEnumerable<User> WithoutPassword(this IEnumerable<User> users) {
            return users.Select(WithoutPassword);
        }

        public static User WithoutPassword(this User user) {
            user.Password = null;
            return user;
        }

    }
}