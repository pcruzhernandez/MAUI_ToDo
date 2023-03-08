﻿using TodoREST.Models;

namespace TodoREST.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTasksAsync();
        Task<List<TodoTickets>> GetTasksTicketsAsync(TodoItem item);
        Task SaveTaskAsync(TodoItem item, bool isNewItem);
        Task DeleteTaskAsync(TodoItem item);
    }
}
