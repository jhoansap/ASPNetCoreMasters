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

        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }


        public IEnumerable<ItemDTO> GetAll()
        {
            var items = this._itemRepository.All().Select(i => new ItemDTO
            {
                Id = i.Id,
                Text = i.Text
            }).AsEnumerable();

            return items;
        }

        public IEnumerable<ItemDTO> GetAllByFilters(ItemByFilterDTO itemByFilterDTO)
        {
            var items = this._itemRepository.All().Where(i => i.Id == itemByFilterDTO.Id || i.Text == itemByFilterDTO.Text)
                                                    .Select(i => new ItemDTO { Id = i.Id, Text = i.Text });
            return items;
        }

        public ItemDTO Get(int itemId)
        {
           
            var item = this._itemRepository.All().Where(i => i.Id == itemId).FirstOrDefault();
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
                Text = itemDto.Text
            };
            this._itemRepository.Save(item);
        }

        public void Update(ItemDTO itemDto)
        {
            var item = new Item
            {
                Id = itemDto.Id,
                Text = itemDto.Text
            };
            this._itemRepository.Save(item);
        }

        public void Delete(int itemId)
        {
            this._itemRepository.Delete(itemId);
        }

        public bool ItemExist(int itemId)
        {
            var item = this._itemRepository.All().Where(i => i.Id == itemId).FirstOrDefault();
            if (item != null) 
                return true; 
            else 
                return false;
             
        }
    }
}
