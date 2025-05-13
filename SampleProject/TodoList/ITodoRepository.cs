using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList
{
    public interface ITodoRepository
    {
        Task<TodoItem> AddAsync(TodoItem item);
        Task<TodoItem> GetByIdAsync(Guid id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<IEnumerable<TodoItem>> GetOpenItemsAsync();
        Task<IEnumerable<TodoItem>> GetCompletedItemsAsync();
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(Guid id);
    }
} 