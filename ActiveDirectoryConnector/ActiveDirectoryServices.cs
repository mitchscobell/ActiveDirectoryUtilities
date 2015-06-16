using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryConnector
{
    public static class ActiveDirectoryServices
    {
        public static List<UserPrincipal> GetUsersFromGroup(string activeDirectoryGroup)
        {
            List<UserPrincipal> users = new List<UserPrincipal>();

            if (activeDirectoryGroup != "")
            {
                try
                {
                    // set up the domain context
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, Environment.UserDomainName);

                    // find the group in question
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, activeDirectoryGroup);

                    foreach (Principal p in group.GetMembers())
                    {

                        // add the users to the list
                        UserPrincipal user = p as UserPrincipal;

                        users.Add(user);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return users;

        }
    }
}
