using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; set; }

        private UserResponse(bool success, string message, User user) : base(success, message) { }

        public UserResponse(User user) : this(true, string.Empty, user) { }

        public UserResponse(string message) : this(false, message, null) { }
    }
}
