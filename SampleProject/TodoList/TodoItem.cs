using System;

namespace TodoList
{
    public class TodoItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public TodoItem(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            IsCompleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsCompleted()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Todo item is already completed");

            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
        }
    }
} 