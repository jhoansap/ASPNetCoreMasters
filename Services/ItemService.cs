using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ItemService
    {
        public int GetAll(int userId)
        {
            return userId;
        }

        public void Save(ItemDTO itemDTO)
        {
            var item = new Item()
            {
                Text = itemDTO.Text
            };
            
        }

    }
}
