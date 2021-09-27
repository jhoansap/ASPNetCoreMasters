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

        private readonly List<Item> items = new List<Item>() {
                new Item(){ Id = 1, Text="user1"},
                new Item(){ Id = 2, Text="user2"},
                new Item(){ Id = 3, Text="user3"}
            };

        public Item GetById(int itemId)
        {
            var item = new Item();
            item = items.FirstOrDefault(i => i.Id == itemId);
            return item;
        }

        public Dictionary<string, string> GetByFilters(Dictionary<string, string> filters)
        {
            return filters;
        }

        public List<Item> GetAll()
        {
            return items;
        }

        public void Save(ItemDTO itemDTO)
        {
            var item = new Item()
            {
                Id = itemDTO.Id,
                Text = itemDTO.Text
            };
            
        }

        public void Update(int itemId, ItemDTO itemDTO)
        {
            var item = new Item()
            {
                Id = itemDTO.Id,
                Text = itemDTO.Text
            };
        }

        public string Delete(int itemId)
        {
            return "Delete " + itemId;
        }

    }
}
