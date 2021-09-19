using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Item
    {
        //[Required]
        //[StringLength(128, ErrorMessage = "Text Max length is 128 and Min Length is 1", MinimumLength = 10)]
        public string Text { get; set; }
    }
}
