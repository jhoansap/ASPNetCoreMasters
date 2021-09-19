﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.BindingModels
{
    public class ItemCreateBindingModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Text Max length is 128 and Min Length is 6", MinimumLength = 1)]
        public string Text { get; set; }
    }
}