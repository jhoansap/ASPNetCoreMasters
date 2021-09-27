using ASPNetCoreMastersTodoList.API.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController()
        {
            this._itemService = new ItemService();
        }

        [HttpGet("/items")]
        public IActionResult Get()
        {
            return Ok(_itemService.GetAll());
        }

        [HttpGet]
        [Route("/items/{itemId}")]
        public IActionResult Get(int itemId)
        {
            return Ok(_itemService.GetById(itemId));
        }


        [HttpGet]
        [Route("/items/filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            return Ok(_itemService.GetByFilters(filters));
        }

        [HttpPost("/items")]
        public IActionResult Post(ItemCreateBindingModel model)
        {
            _itemService.Save(new ItemDTO() { Text = model.Text });
            return Ok();
        }

        [HttpPut("/items/{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            _itemService.Update(itemId, new ItemDTO() { Text = itemUpdateModel.Text });
            return Ok();
        }


        [HttpDelete("/items/{itemId}")]
        public IActionResult Delete(int itemId)
        {
            return Ok(_itemService.Delete(itemId));
        }
    }
}
