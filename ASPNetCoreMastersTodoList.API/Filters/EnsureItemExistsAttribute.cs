using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.Filters
{
    public class EnsureItemExistsFilter : IActionFilter
    {
        private readonly IItemService _itemService;

        public EnsureItemExistsFilter(IItemService itemService)
        {
            this._itemService = itemService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {   
            _ = context.ActionArguments.TryGetValue("itemId", out object objId) ? objId : null;
            if (objId != null)
            {
                int itemId = (int)objId;
                if (!_itemService.ItemExist(itemId))
                {
                    context.Result = new NotFoundResult();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

       
    }

    public class EnsureItemExistsAttribute : TypeFilterAttribute
    {
        public EnsureItemExistsAttribute() : base(typeof(EnsureItemExistsFilter))
        { }
    }
}
