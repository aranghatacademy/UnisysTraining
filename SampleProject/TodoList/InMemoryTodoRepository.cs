using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly Dictionary<Guid, TodoItem> _items;

        public InMemoryTodoRepository()
        {
            _items = new Dictionary<Guid, TodoItem>();
        }

        public Task<TodoItem> AddAsync(TodoItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items[item.Id] = item;
            return Task.FromResult(item);
        }

        public Task<TodoItem> GetByIdAsync(Guid id)
        {
            if (_items.TryGetValue(id, out var item))
            {
                return Task.FromResult(item);
            }
            return Task.FromResult<TodoItem>(null);
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return Task.FromResult(_items.Values.AsEnumerable());
        }

        public Task<IEnumerable<TodoItem>> GetOpenItemsAsync()
        {
            return Task.FromResult(_items.Values.Where(x => !x.IsCompleted));
        }

        public Task<IEnumerable<TodoItem>> GetCompletedItemsAsync()
        {
            return Task.FromResult(_items.Values.Where(x => x.IsCompleted));
        }

        public Task UpdateAsync(TodoItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_items.ContainsKey(item.Id))
                throw new KeyNotFoundException($"Todo item with ID {item.Id} not found");

            _items[item.Id] = item;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            if (!_items.ContainsKey(id))
                throw new KeyNotFoundException($"Todo item with ID {id} not found");

            _items.Remove(id);
            return Task.CompletedTask;
        }
    }
} 