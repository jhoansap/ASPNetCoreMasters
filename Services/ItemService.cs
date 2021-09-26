using DomainModels;
using Repositories;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ItemService:IItemService
    {

        IItemRepository itemRepository = new ItemRepository();


        public IEnumerable<ItemDTO> GetAll()
        {
            var items = itemRepository.All().Select(i => new ItemDTO
            {
                Id = i.Id,
                Text = i.Text
            }).AsEnumerable();

            return items;
        }

        public IEnumerable<ItemDTO> GetAllByFilters(Dictionary<string, string> filters)
        {
            //var items = itemRepository.All().Where
            return Enumerable.Empty<ItemDTO>();
        }

        public ItemDTO Get(int itemId)
        {
           
            var item = itemRepository.All().Where(i => i.Id == itemId).FirstOrDefault();
            ItemDTO itemDTO = new ItemDTO();
            if (item != null)
            {
                itemDTO.Id = item.Id;
                itemDTO.Text = item.Text;
            }
            return itemDTO;
        }

        public void Add(ItemDTO itemDto)
        {
            var item = new Item
            {
                Id = itemDto.Id,
                Text = itemDto.Text
            };
            itemRepository.Save(item);
        }

        public void Update(ItemDTO itemDto)
        {
            var item = new Item
            {
                Id = itemDto.Id,
                Text = itemDto.Text
            };
            //update
        }

        public void Delete(int id)
        {
            itemRepository.Delete(id);
        }
    }
}
