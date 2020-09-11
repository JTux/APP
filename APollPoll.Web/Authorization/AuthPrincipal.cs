using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace APollPoll.Web.Authorization
{
    public class AuthPrincipal : IPrincipal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            return Role.ToLower() == role.ToLower();
        }

        public AuthPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}