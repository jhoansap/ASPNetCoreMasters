using ASPNetCoreMastersTodoList.API.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.API.Filters;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DomainModels;
using Microsoft.AspNetCore.Identity;

namespace ASPNetCoreMastersTodoList.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [EnsureItemExists]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser> _userService;
        private readonly IAuthorizationService _authService;

        public ItemsController(IItemService itemService, IAuthorizationService authService, UserManager<IdentityUser> userService)
        {
            _itemService = itemService;
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemService.GetAll());
        }

        [HttpGet]
        [Route("{itemId}")]
        public IActionResult Get(int itemId)
        {
             return Ok(_itemService.Get(itemId));
        }


        [HttpGet]
        [Route("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            string sText = filters.TryGetValue("text", out sText) ? sText : string.Empty;
            string sId = filters.TryGetValue("id", out sId) ? sId : string.Empty;
            var item = new ItemByFilterDTO()
                 { Id = int.TryParse(sId, out int id) ? id : 0,
                   Text = sText};
            return Ok(_itemService.GetAllByFilters(item));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var email = ((ClaimsIdentity)User.Identity).FindFirst("Email");
            var user = await _userService.FindByNameAsync(email.Value);

            _itemService.Add(new ItemDTO() { Text = itemCreateModel.Text }, user);
            
            return Ok();
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var item = _itemService.Get(itemId);
            var authResult = await _authService.AuthorizeAsync(User, new ItemDTO(){CreatedBy = item.CreatedBy}, "CanEditItems");

            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            _itemService.Update(new ItemDTO()
            {
                Id = itemId,
                Text = itemUpdateModel.Text
            });

            return Ok();
        }


        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            _itemService.Delete(itemId);
            return Ok();
        }
    }
}
