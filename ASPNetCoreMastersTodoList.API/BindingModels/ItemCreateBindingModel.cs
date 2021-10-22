using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.BindingModels
{
    public class ItemCreateBindingModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Text Max length is 128 and Min Length is 1", MinimumLength = 1)]
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
