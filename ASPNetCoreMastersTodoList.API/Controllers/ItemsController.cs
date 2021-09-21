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
        public void Post([FromBody] ItemCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                _itemService.Save(new ItemDTO() { Text = model.Text });
            }
        }
    }
}
