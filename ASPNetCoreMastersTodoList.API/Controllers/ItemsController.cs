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

namespace ASPNetCoreMastersTodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnsureItemExists]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
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
        public IActionResult Post(ItemCreateBindingModel model)
        {
            _itemService.Add(new ItemDTO() { Text = model.Text });
            return Ok();
        }

        [HttpPut("{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            _itemService.Update(new ItemDTO() {  
                                    Id = itemUpdateModel.Id,
                                    Text = itemUpdateModel.Text });
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
