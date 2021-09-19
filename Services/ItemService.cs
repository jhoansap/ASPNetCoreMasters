using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll(int userId)
        {
            IEnumerable<string> empty = Enumerable.Empty<string>();
            return empty;
        }
    }
}
