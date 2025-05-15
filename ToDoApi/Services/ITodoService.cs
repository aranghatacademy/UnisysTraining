using ToDoApi.Models;

namespace ToDoApi.Services
{
    public interface ITodoService
    {
        List<ToDoItem> GetAll();

        List<ToDoItem> GetPendingItems();

        ToDoItem Add(ToDoItem item);

        void MarkAsCompleted(int id);
    }

    public class TodoService : ITodoService
    {
        private static readonly List<ToDoItem> _items = new List<ToDoItem>();
        public List<ToDoItem> GetAll()
        {
            return _items;
        }
        public List<ToDoItem> GetPendingItems()
        {
            return _items.Where(item => !item.IsCompleted).ToList();
        }
        public ToDoItem Add(ToDoItem item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return item;
        }

        public void MarkAsCompleted(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsCompleted = true;
            }
        }
    }
}
