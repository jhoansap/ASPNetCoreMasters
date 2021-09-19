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
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController()
        {
            this._itemService = new ItemService();
        }

        [HttpGet]
        public int Get(int Id)
        {
            return _itemService.GetAll(Id);
        }

        [HttpPost]
        public void Post([FromQuery] ItemCreateBindingModel model)
        {
            ItemDTO text = new ItemDTO { Text = model.Text }; 

            _itemService.Save(text);
        }
    }
}
