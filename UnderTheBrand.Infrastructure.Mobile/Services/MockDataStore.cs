using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Entity;

namespace UnderTheBrand.Infrastructure.Mobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> _items;

        public MockDataStore()
        {
            _items = new List<Item>()
            {
                new Item { Text = "First item", Description="This is an item description." },
                new Item { Text = "Second item", Description="This is an item description." },
                new Item { Text = "Third item", Description="This is an item description." },
                new Item { Text = "Fourth item", Description="This is an item description." },
                new Item { Text = "Fifth item", Description="This is an item description." },
                new Item { Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(oldItem);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
            _items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}