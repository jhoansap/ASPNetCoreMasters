﻿using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
