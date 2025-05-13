using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<TodoItem> AddItemAsync(string title, string description)
        {
            var todoItem = new TodoItem(title, description);
            return await _repository.AddAsync(todoItem);
        }

        public async Task MarkAsCompletedAsync(Guid id)
        {
            var todoItem = await _repository.GetByIdAsync(id);
            if (todoItem == null)
                throw new KeyNotFoundException($"Todo item with ID {id} not found");

            todoItem.MarkAsCompleted();
            await _repository.UpdateAsync(todoItem);
        }

        public async Task<IEnumerable<TodoItem>> GetOpenItemsAsync()
        {
            return await _repository.GetOpenItemsAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetCompletedItemsAsync()
        {
            return await _repository.GetCompletedItemsAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(Guid id)
        {
            var todoItem = await _repository.GetByIdAsync(id);
            if (todoItem == null)
                throw new KeyNotFoundException($"Todo item with ID {id} not found");

            return todoItem;
        }

        public async Task RemoveItemAsync(Guid id)
        {
            var todoItem = await _repository.GetByIdAsync(id);
            if (todoItem == null)
                throw new KeyNotFoundException($"Todo item with ID {id} not found");

            await _repository.DeleteAsync(id);
        }
    }
} 