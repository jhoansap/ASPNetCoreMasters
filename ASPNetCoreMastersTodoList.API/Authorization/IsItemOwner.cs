using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.Authorization
{
    public class IsItemOwnerRequirement : IAuthorizationRequirement { }

    public class IsItemOwnerHandler : AuthorizationHandler<IsItemOwnerRequirement, ItemDTO>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IsItemOwnerHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsItemOwnerRequirement requirement,
            ItemDTO resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }

            if (resource.CreatedBy == appUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
