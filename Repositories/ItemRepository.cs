using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {

        //private readonly DataContext _dataContext;

        //public ItemRepository(DataContext dataContext)
        //{
        //    this._dataContext = dataContext;
        //}

        private readonly DataDBContext _dataContext;

        public ItemRepository(DataDBContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            var items = this._dataContext.Items.AsQueryable();
            return items;
        }
             

        public void Delete(int id)
        {
            Item item = this._dataContext.Items.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
                this._dataContext.Items.Remove(item);
        }

        public void Save(Item item)
        {
            if (item.Id == 0)
            {
                var maxVal = _dataContext.Items.Select(i => i.Id).Max();
                item.Id = maxVal + 1;
                this._dataContext.Items.Add(item);
            }
            else
            {
                var selectedItem = this._dataContext.Items.Where(i => i.Id == item.Id).FirstOrDefault();
                if (selectedItem != null)
                {
                    selectedItem.Text = item.Text;
                }
                else
                {
                    this._dataContext.Items.Add(item);
                }
            }
        }
    }
}
