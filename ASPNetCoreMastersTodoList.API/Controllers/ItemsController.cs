using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
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

        [HttpGet]
        public IEnumerable<string> Get(int Id)
        {

            return _itemService.GetAll(Id);

        }

    }
}
