using DomainModels;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class DataContext
    {
       public List<Item> Items = new List<Item>() {
                new Item(){ Id = 1, Text="testdata1"},
                new Item(){ Id = 2, Text="testdata2"},
                new Item(){ Id = 3, Text="testdata3"}
            };
    }
}
