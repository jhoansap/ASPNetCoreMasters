using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.BindingModels
{
    public class ItemUpdateBindingModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
