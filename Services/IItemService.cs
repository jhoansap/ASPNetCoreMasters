using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IItemService
    {
        public IEnumerable<ItemDTO> GetAll();
        public IEnumerable<ItemDTO> GetAllByFilters(Dictionary<string, string> filters);
        public ItemDTO Get(int itemId);
        public void Add(ItemDTO itemDto);
        public void Update(ItemDTO itemDTO);
        public void Delete(int id);
    }
}
