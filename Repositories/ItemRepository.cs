using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {

        DataContext dataContext = new DataContext();

        public IQueryable<Item> All()
        {
            var items = dataContext.Items.AsQueryable();
            return items;
        }
             

        public void Delete(int id)
        {
            Item item = dataContext.Items.Where(i => i.Id == id).FirstOrDefault();
            if (item != null) 
                dataContext.Items.Remove(item);
        }

        public void Save(Item item)
        {
            if (item.Id == 0)
                dataContext.Items.Add(item);
            else
            {
                Item selectedItem = dataContext.Items.Where(i => i.Id == item.Id).FirstOrDefault();
                selectedItem.Text = item.Text;
            }
        }
    }
}
