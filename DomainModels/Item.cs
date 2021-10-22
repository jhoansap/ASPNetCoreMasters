﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
